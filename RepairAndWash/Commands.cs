using Rage;
using Rage.Attributes;

namespace RepairAndWash
{
	class Commands
	{
		/// <summary>
		/// Console Command Reload Plugin
		/// </summary>
		[ConsoleCommand]
		static void RAWReloadINI()
		{
			INI.IniHandler();
			Game.DisplayNotification("~g~RELOADED RAW's INI FILE");
		}

		/// <summary>
		/// Command for Writing the Error List
		/// </summary>
		[ConsoleCommand]
		static void RAWWriteErrorList()
		{
			Error.printErrorList();
		}

		/// <summary>
		/// Command for printing the Log.
		/// </summary>
		[ConsoleCommand]
		static void RAWWriteLog()
		{
			Error.printLog();
		}

		[ConsoleCommand]
		static void TestPlayerWash()
		{
			Ped player = Game.LocalPlayer.Character;
			Ped attacker = new Ped(player.Position);
			player.MaxHealth = 50000000;
			player.Health = player.MaxHealth;
			attacker.Inventory.GiveNewWeapon(, -1 ,true)
			;
			attacker.Tasks.FightAgainst(player);
		}
	}
}
