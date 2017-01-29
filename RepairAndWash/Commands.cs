// ****************************** Module Header ****************************** //
//
// Last Modified: 29:01:2017 / 02:13
// Creation: 03:01:2017
// Project: RepairAndWash
//
// <copyright file="Commands.cs" company="Patrick Hollweck">//</copyright>
// *************************************************************************** //
namespace RepairAndWash
{
	using Rage;
	using Rage.Attributes;

	internal class Commands
	{
		/// <summary>
		/// Console Command Reload Plugin
		/// </summary>
		[ConsoleCommand]
		public static void RAWReloadIni()
		{
			Config.IniHandler();
			Game.DisplayNotification("~g~RELOADED RAW's INI FILE");
		}

		/// <summary>
		/// Command for Writing the Error List
		/// </summary>
		[ConsoleCommand]
		public static void RAWWriteErrorList()
		{
			//Error.PrintErrorList();
		}

		/// <summary>
		/// Command for printing the Log.
		/// </summary>
		[ConsoleCommand]
		public static void RAWWriteLog()
		{
			//Error.PrintLog();
		}

		[ConsoleCommand]
		public static void TestPlayerWash()
		{
			Ped player = Game.LocalPlayer.Character;
			Ped attacker = new Ped(player.Position);
			player.MaxHealth = 50000000;
			player.Health = player.MaxHealth;
			attacker.Inventory.GiveNewWeapon("Pistol", -1, true);
			attacker.Tasks.FightAgainst(player);
		}
	}
}