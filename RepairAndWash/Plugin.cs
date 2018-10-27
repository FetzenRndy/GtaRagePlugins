// ****************************** Module Header ****************************** //
//
//
// Last Modified: 01:03:2017 / 00:14
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
	using System;

	// Rage exposes a Rage.Task class. Which creates a name clash.
	using DotNetTask = System.Threading.Tasks.Task;

	using Rage;

	using RepairAndWash.Core.Common;
	using RepairAndWash.Core.Components;
	using RepairAndWash.Core.Components.ErrorReporting;
	using RepairAndWash.Core.Components.ErrorReporting.Reporters;

	/// <summary>
	/// Main logic and Entry Point of the Plugin
	/// </summary>
	public static class Plugin
	{
		/// <summary>
		/// Main Entry Point of the Plugin
		/// </summary>
		[STAThread]
		public static void Main()
		{
			try
			{
				ErrorHandler.RegisterReporter(new IngameMessageReporter());

				// TODO: Load settings from config.
				StartPlugin();

				Util.DisplayNotification($"~b~RepairAndWash ~w~V {Global.Application.CurrentVersion} has been loaded ~g~Successfully~w");

				DotNetTask.Run(async () => { await Updater.CheckUpdate(); });
			}
			catch (Exception exception)
			{
				ErrorHandler.Report("Something went wrong :(", exception);
			}
		}

		/// <summary>
		/// Sets up a new GameFibre and Enteres the Main Programm flow
		/// </summary>
		private static void StartPlugin()
		{
			GameFiber.StartNew(() => WaitForKeydown());
		}

		/// <summary>Executes a action based on KeyPress</summary>
		/// <param name="action">The action.</param>
		private static void OnKeyDown(Global.Enums.Action action)
		{
			// Gets the LocalPlayer and the CurrentVehicle if he is in one
			Ped player = Game.LocalPlayer.Character;
			Vehicle playerVehicle = player.CurrentVehicle;

			// If the PlayersVehicle is null he is not in a Vehicle -> Can't be Repairedjddkkjj
			if (playerVehicle == null)
			{
				Util.DisplayNotification("~r~You are not in a Vehicle...");
				return;
			}

			// String Containing the Type of the Vehicle obtained by Calling a Helper Methode
			string playerVehicleType = Util.GetVehicleType(playerVehicle);

			// Execute a Function based on the Action Param
			if (action == Global.Enums.Action.RepairAndWash)
			{
				// Repaires the PlayerVehicle
				playerVehicle.Repair();
				// Washes the PlayerVehicle
				playerVehicle.Wash();

				// Play a Sound and Display a Notification if not Disabled by the User
				Util.DisplayNotification("~g~Repaired and cleaned your " + playerVehicleType + "!");
			}
			else if (action == Global.Enums.Action.Repair)
			{
				playerVehicle.Repair();

				Util.DisplayNotification("~g~Repaired your vehicle " + playerVehicleType + "!");
			}
			else if (action == Global.Enums.Action.Wash)
			{
				playerVehicle.Wash();

				Util.DisplayNotification("~g~Cleaned your vehicle " + playerVehicleType + "!");
			}
		}

		/// <summary>
		/// Wait until key is Pressed.
		/// </summary>
		private static void WaitForKeydown()
		{
			while (true)
			{
				GameFiber.Yield();

				if (Game.IsKeyDown(Global.Controls.RepairAndWash))
				{
					OnKeyDown(Global.Enums.Action.RepairAndWash);
					return;
				}

				if (Game.IsKeyDown(Global.Controls.Wash))
				{
					OnKeyDown(Global.Enums.Action.Wash);
					return;
				}

				if (Game.IsKeyDown(Global.Controls.Repair))
				{
					OnKeyDown(Global.Enums.Action.Repair);
					return;
				}
			}
		}
	}
}