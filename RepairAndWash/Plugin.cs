// ****************************** Module Header ****************************** //
//
// Last Modified: 29:01:2017 / 16:07
// Creation: 01:01:2017
// Project: RepairAndWash
//
// <copyright file="Plugin.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

using Rage.Attributes;

[assembly: Plugin("RepairAndWash", Description = "Repairs and Washes your vehicle on KeyPress", PrefersSingleInstance = true, Author = "Patrick Hollweck")]

namespace RepairAndWash
{
	using Rage;

	public class Plugin
	{
		public static void Main()
		{
			Audio.Setup();
			Config.IniHandler();
			StartPlugin();

			Game.DisplayNotification("~b~RepairAndWash ~w~V" + global.CurrentVersion + " Has been loaded ~g~Successfully.");
		}

		/// <summary>Executes a Action based on KeyPress</summary>
		/// <param name="Action">The Action.</param>
		private static void OnKeyDown(string Action)
		{
			Ped player = Game.LocalPlayer.Character;
			Vehicle playerVehicle = player.CurrentVehicle;

			if (playerVehicle != null)
			{
				string playerVehicleType = Util.GetVehicleType(playerVehicle);

				// Actions
				if (Action == "RepairAndClean")
				{
					if (global.isAudioEnables)
					{
						global.RepairSound.Play();
					}

					playerVehicle.Repair();
					playerVehicle.Wash();

					if (global.ShowNotifications)
					{
						Util.DisplayNotificationType(global.NotificationsType, "~g~Repaired and cleaned your " + playerVehicleType + "!");
					}
				}
				else if (Action == "Repair")
				{
					if (global.isAudioEnables)
					{
						global.RepairSound.Play();
					}

					playerVehicle.Repair();

					if (global.ShowNotifications)
					{
						Util.DisplayNotificationType(global.NotificationsType, "~g~Repaired your vehicle " + playerVehicleType + "!");
					}
				}
				else if (Action == "Clean")
				{
					if (global.isAudioEnables)
					{
						global.WashSound.Play();
					}

					playerVehicle.Wash();

					if (global.ShowNotifications)
					{
						Util.DisplayNotificationType(global.NotificationsType, "~g~Cleaned your vehicle " + playerVehicleType + "!");
					}
				}
			}
			else
			{
				if (global.ShowNotifications)
				{
					Util.DisplayNotificationType(global.NotificationsType, "~r~You are not in a Vehicle...");
				}
			}

			if (Action == "WashPlayer")
			{
				Util.DisplayNotificationType(global.NotificationsType, "~r~Washed Player...");
				player.Clone();
				player.Delete();

				// player = new Ped(player.Model,player.Position, player.Heading);
			}

			WaitForKeydown();
		}

		/// <summary>
		/// Sets up a new GameFiber and wait for Activation of the Key. Then call the OnActivation function
		/// </summary>
		private static void StartPlugin()
		{
			GameFiber.StartNew(
				delegate
					{
						WaitForKeydown();
					});
		}

		/// <summary>
		/// Wait until key is Pressed.
		/// </summary>
		private static void WaitForKeydown()
		{
			while (true)
			{
				GameFiber.Yield();

				if (Game.IsKeyDown(global.KeyCleanAndRepair))
				{
					OnKeyDown("RepairAndClean");
					break;
				}

				if (Game.IsKeyDown(global.KeyClean))
				{
					OnKeyDown("Clean");
					break;
				}

				if (Game.IsKeyDown(global.KeyRepair))
				{
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
	}
}