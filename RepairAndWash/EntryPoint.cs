using System;
using Rage;
using System.Media;
using Rage.Attributes;

[assembly:
	Plugin("RepairAndWash", Description = "Repairs and Washes your vehicle on KeyPress", PrefersSingleInstance = true,
		Author = "Patrick Hollweck")]

/*
 * Developed by Patrick Hollweck - GitHub: https://github.com/FetzenRndy;
 * This Plugin makes washing and repairing your vehicle simpler than ever before.
 */

// TODO: Better Logg-ing and Error Handling, Update the README, Notification type
// Proper error Handling for Audio.

namespace RepairAndWash
{
	public class EntryPoint
	{
		/// <summary>
		/// Main Entry Point of the RAW Plugin
		/// </summary>
		public static void Main()
		{
			Error.Log("Startup", "Main function call - Starting");
			INI.IniHandler();
			StartPlugin();
			Updater.Update();
			//TODO: ERROR CHECK METHODE

			Error.Log("Startup", "Main Startup finished with " + Error.errorCounter + "Error(s)");
			if (global.errors == 0)
			{
				Game.DisplayNotification("~b~RepairAndWash ~w~V" + global.CurrentVersion + " Has been loaded ~g~Successfully.");
			}
			else
			{
				Game.DisplayNotification("~b~RepairAndWash ~w~Has been loaded ~r~But there were " + global.errors +
				                         " Error(s)! For a Error Log type 'WriteErrorListRAW' in the Console");
				Error.printErrorList();
			}
		}

		/// <summary>
		/// Sets up a new GameFibre and wait for Activation of the Key. Then call the OnActivation function
		/// </summary>
		public static void StartPlugin()
		{
			Game.LogTrivial("Waiting for Activation");
			GameFiber.StartNew(delegate
			{
				try
				{
					global.RepairSound = new SoundPlayer("Plugins/RAW/repair.wav");
					global.WashSound = new SoundPlayer("Plugins/RAW/clean.wav");
				}
				catch (Exception err)
				{
					Error.newError("AUDIO ERROR", "There was an exception when loading the Audio...", err.Message, err.StackTrace);
					Game.DisplaySubtitle(
						"ERROR while loading the Audio files - Please execute the 'RAWWriteErrorLog' command for a detailed error Report (Will be generated into your Plugins folder");
				}

				WaitForKeydown();
				Game.LogTrivial("Loaded! - log");
			});
		}

		/// <summary>
		/// Wait until key is Pressed.
		/// </summary>
		public static void WaitForKeydown()
		{
			while (true)
			{
				GameFiber.Yield();

				if (Game.IsKeyDown(global.KeyCleanAndRepair))
				{
					Game.LogTrivial("KeyCleanAndRepair - KEYDOWN!");
					OnKeyDown("RepairAndClean");
					break;
				}

				if (Game.IsKeyDown(global.KeyClean))
				{
					Game.LogTrivial("KeyClean - KEYDOWN!");
					OnKeyDown("Clean");
					break;
				}

				if (Game.IsKeyDown(global.KeyRepair))
				{
					Game.LogTrivial("KeyRepair - KEYDOWN!");
					OnKeyDown("Repair");
					break;
				}

				if (Game.IsKeyDown(global.KeyCleanPlayer))
				{
					OnKeyDown("WashPlayer");
					break;
				}
			}
		}

		/// <summary>
		/// According to the user wished action eighther clean, repair or Clean and Repair the Vehicle and Wait for another key down;
		/// </summary>
		public static void OnKeyDown(string Action)
		{
			Ped player = Game.LocalPlayer.Character;
			Vehicle playerVehicle = player.CurrentVehicle;

			if (playerVehicle != null)
			{
				string playerVehicleType = GetVehicleType(playerVehicle);

				//Actions
				if (Action == "RepairAndClean")
				{
					if (global.PlaySound)
					{
						global.RepairSound.Play();
					}

					playerVehicle.Repair();
					playerVehicle.Wash();

					Game.LogTrivial("Repaired and cleaned");

					if (global.ShowNotifications)
					{
						DisplayNotificationType(global.NotificationsType, "~g~Repaired and cleaned your " + playerVehicleType + "!");
					}
				}
				else if (Action == "Repair")
				{
					if (global.PlaySound)
					{
						global.RepairSound.Play();
					}

					playerVehicle.Repair();

					Game.LogTrivial("Repaired");

					if (global.ShowNotifications)
					{
						DisplayNotificationType(global.NotificationsType, "~g~Repaired your vehicle " + playerVehicleType + "!");
					}
				}
				else if (Action == "Clean")
				{
					if (global.PlaySound)
					{
						global.WashSound.Play();
					}

					playerVehicle.Wash();

					Game.LogTrivial("Cleaned");

					if (global.ShowNotifications)
					{
						DisplayNotificationType(global.NotificationsType,"~g~Cleaned your vehicle " + playerVehicleType + "!");
					}
				}
			}
			else
			{
				if (global.ShowNotifications)
				{
					DisplayNotificationType(global.NotificationsType ,"~r~You are not in a Vehicle...");
				}
			}

			if (Action == "WashPlayer")
			{
				DisplayNotificationType(global.NotificationsType, "~r~Washed Player...");
				player.Clone();
				player.Delete();
				//player = new Ped(player.Model,player.Position, player.Heading);
			}

			WaitForKeydown();
		}

		/// <summary>
		/// Displays a Notifications depending on the INI files configuration.
		/// </summary>
		public static void DisplayNotificationType(string type, string Message)
		{
			retry:

			if (global.ShowNotifications)
			{
				if (type == "top")
				{
					Game.DisplayHelp(Message);
				}
				else if (type == "notification")
				{
					Game.DisplayNotification(Message);
				}
				else if (type == "sub")
				{
					Game.DisplaySubtitle(Message);
				}
				else
				{
					type = "top";
					Error.newError("INI ERROR", "The Notification type if not vaild!");
					goto retry;
				}
			}
		}

		/// <summary>
		/// Get the type of vehicle the Player is Driving.
		/// </summary>
		public static string GetVehicleType(Vehicle playerVehicle)
		{
			string playerVehicleType;

			//Get Type of the Vehicle.
			if (playerVehicle.IsBicycle)
			{
				playerVehicleType = "Bicycle";
			}
			else if (playerVehicle.IsPoliceVehicle)
			{
				playerVehicleType = "Police Vehicle";
			}
			else if (playerVehicle.IsBig)
			{
				playerVehicleType = "Truck / Bus / Plane";
			}
			else if (playerVehicle.IsBike)
			{
				playerVehicleType = "Bike";
			}
			else if (playerVehicle.IsBlimp)
			{
				playerVehicleType = "Blimp";
			}
			else if (playerVehicle.IsBoat)
			{
				playerVehicleType = "Boat";
			}
			else if (playerVehicle.IsCar)
			{
				playerVehicleType = "Car";
			}
			else if (playerVehicle.IsHelicopter)
			{
				playerVehicleType = "Helicopter";
			}
			else if (playerVehicle.IsPlane)
			{
				playerVehicleType = "Plane";
			}
			else if (playerVehicle.IsQuadBike)
			{
				playerVehicleType = "QuadBike";
			}
			else if (playerVehicle.IsSubmarine)
			{
				playerVehicleType = "Submarine";
			}
			else if (playerVehicle.IsTrain)
			{
				playerVehicleType = "Train";
			}
			else
			{
				playerVehicleType = "Vehicle";
			}

			return playerVehicleType;
		}
	}
}
