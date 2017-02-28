// ****************************** Module Header ****************************** //
//
//
// Last Modified: 28:02:2017 / 17:33
// Creation: 28:02:2017
// Project: RepairAndWash
//
//
// <copyright file="Plugin.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

using Rage.Attributes;

[assembly: Plugin("RepairAndWash", Description = "Repairs and Washes your vehicle on KeyPress", PrefersSingleInstance = true, Author = "Patrick Hollweck")]

namespace RepairAndWash
{
	using Rage;
	using Rage.Forms;

	using RepairAndWash.Core.Common;
	using RepairAndWash.Core.Components;

	public static class Plugin
	{
		public static void Main()
		{
			Config.Setup();
			Audio.Setup();
			Updater.CheckUpdate();
			StartPlugin();

			Game.DisplayNotification("~b~RepairAndWash ~w~V" + Global.Application.CurrentVersion + " Has been loaded ~g~Successfully.");
		}

		/// <summary>Executes a Action based on KeyPress</summary>
		/// <param name="Action">The Action.</param>
		private static void OnKeyDown(string Action)
		{
			Ped player = Game.LocalPlayer.Character;
			Vehicle playerVehicle = player.CurrentVehicle;

			if (playerVehicle != null)
			{
				return;
			}

			string playerVehicleType = Util.GetVehicleType(playerVehicle);

			// Actions
			if (Action == "RepairAndClean")
			{
				Audio.PlaySound(Global.Sound.Sounds.RepairAndWash);

				playerVehicle.Repair();
				playerVehicle.Wash();

				Util.DisplayNotificationType("~g~Repaired and cleaned your " + playerVehicleType + "!");
			}
			else if (Action == "Repair")
			{
				Audio.PlaySound(Global.Sound.Sounds.Repair);

				playerVehicle.Repair();

				Util.DisplayNotificationType("~g~Repaired your vehicle " + playerVehicleType + "!");
			}
			else if (Action == "Clean")
			{
				Audio.PlaySound(Global.Sound.Sounds.Wash);

				playerVehicle.Wash();

				Util.DisplayNotificationType("~g~Cleaned your vehicle " + playerVehicleType + "!");
			}
			else if (Action == "WashPlayer")
			{
				Util.DisplayNotificationType("~r~Washed Player...");

				// TODO: PlayerWashing
			}
			else
			{
				Util.DisplayNotificationType("~r~You are not in a Vehicle...");
			}

			WaitForKeydown();
		}

		/// <summary>
		/// Sets up a new GameFiber and wait for Activation of the Key. Then call the OnActivation function
		/// </summary>
		private static void StartPlugin()
		{
			GameFiber.StartNew(
				delegate { WaitForKeydown(); });
		}

		/// <summary>
		/// Wait until key is Pressed.
		/// </summary>
		private static void WaitForKeydown()
		{
			GwenForm form = new GwenForm(typeof(Forms.SettingsForm));

			form.InitializeLayout();
			form.Show();

			while (true)
			{
				GameFiber.Yield();

				/*				if (Game.IsKeyDown(Global.KeyCleanAndRepair))
												{
													OnKeyDown("RepairAndClean");
													break;
												}

												if (Game.IsKeyDown(Global.KeyClean))
												{
													OnKeyDown("Clean");
													break;
												}

												if (Game.IsKeyDown(Global.KeyRepair))
												{
													OnKeyDown("Repair");
													break;
												}

												if (Game.IsKeyDown(Global.KeyCleanPlayer))
												{
													OnKeyDown("WashPlayer");
													break;
												}
								*/
			}
		}
	}
}