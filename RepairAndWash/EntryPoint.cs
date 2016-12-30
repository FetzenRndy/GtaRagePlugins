using System;
using System.IO;
using System.Reflection;
using Rage;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

[assembly:
	Rage.Attributes.Plugin("RepairAndWash", Description = "Repairs and Washes your Car on KeyPress",
		Author = "Patrick Hollweck")]

/*
 * Developed by Patrick Hollweck - GitHub: https://github.com/FetzenRndy;
 * This Plugin makes washing and repairing your car simpler than ever before.
 */

namespace RepairAndWash
{
	public class EntryPoint
	{
		/// <summary>
		/// Main Entry Point of the Plugin
		/// </summary>
		public static void Main()
		{
			IniHandler();

			Game.DisplayNotification("~b~RepairAndWash ~w~ Has been loaded ~g~Successfully.");
			StartPlugin();
		}

		private static Keys KeyCleanAndRepair;
		private static Keys KeyClean;
		private static Keys KeyRepair;


		/// <summary>
		/// Handle the input from the INI file
		/// </summary>
		public static void IniHandler()
		{
			InIFile iniHandler = new InIFile();

			iniHandler.path = "Plugins/RepairAndWash.ini";

			if (!File.Exists(iniHandler.path))
			{
				iniHandler.WriteValue("KEYBINDINGS", "HELP",
					"For Help with the ini file visit : https://msdn.microsoft.com/de-de/library/system.windows.forms.keys(v=vs.110).aspx");
				iniHandler.WriteValue("KEYBINDINGS", "CleaningAndRepairing", "NumPad0");
				iniHandler.WriteValue("KEYBINDINGS", "Cleaning", "NumPad1");
				iniHandler.WriteValue("KEYBINDINGS", "Repairing", "NumPad2");
			}
			else
			{
				KeysConverter kc = new KeysConverter();

				try
				{
					object convertFromString = kc.ConvertFromString(iniHandler.ReadValue("KEYBINDINGS", "CleaningAndRepairing"));
					if (convertFromString != null)
					{
						KeyCleanAndRepair = (Keys) convertFromString;
					}

					object fromString = kc.ConvertFromString(iniHandler.ReadValue("KEYBINDINGS", "Cleaning"));
					if (fromString != null)
					{
						KeyClean = (Keys) fromString;
					}

					object s = kc.ConvertFromString(iniHandler.ReadValue("KEYBINDINGS", "Repairing"));
					if (s != null)
					{
						KeyRepair = (Keys) s;
					}
				}
				catch (Exception)
				{
					Game.DisplaySubtitle("~r~ERROR WHILE TRYING TO PARSE THE INI FILE OF REPAIR AND WASH PLEASE FIX IT!");
				}
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

				if (Game.IsKeyDown(KeyCleanAndRepair))
				{
					Game.LogTrivial("KeyCleanAndRepair - KEYDOWN!");
					OnKeyDown("RepairAndClean");
					break;
				}

				if (Game.IsKeyDown(KeyClean))
				{
					Game.LogTrivial("KeyClean - KEYDOWN!");
					OnKeyDown("Clean");
					break;
				}

				if (Game.IsKeyDown(KeyRepair))
				{
					Game.LogTrivial("KeyRepair - KEYDOWN!");
					OnKeyDown("Repair");
					break;
				}
			}
		}

		/// <summary>
		/// According to the user wished action eighter clean, repair or Clean and Repair the Car and Wait for another keydown;
		/// </summary>
		public static void OnKeyDown(string Action)
		{
			Ped player = Game.LocalPlayer.Character;
			Vehicle playerVehicle = player.CurrentVehicle;

			if (playerVehicle != null)
			{
				if (Action == "RepairAndClean")
				{
					playerVehicle.Repair();
					playerVehicle.Wash();

					Game.LogTrivial("Repaired and cleaned");
					Game.DisplayNotification("~g~Repaired and cleaned your car!");
				}
				else if (Action == "Repair")
				{
					playerVehicle.Repair();

					Game.LogTrivial("Repaired");
					Game.DisplayNotification("~g~Repaired your car!");
				}
				else if (Action == "Clean")
				{
					playerVehicle.Wash();

					Game.LogTrivial("Cleaned");
					Game.DisplayNotification("~g~Cleaned your car!");
				}
			}
			else
			{
				Game.DisplayNotification("~r~You are not in a Vehicle...");
			}

			WaitForKeydown();
		}

		/// <summary>
		/// INI Files handling class
		/// </summary>
		class InIFile
		{
			public string path;

			[DllImport("kernel32")]
			private static extern long WritePrivateProfileString(string section,
			string key, string val, string filePath);

			[DllImport("kernel32")]
			private static extern int GetPrivateProfileString(string section,
			string key, string def, StringBuilder retVal,
			int size, string filePath);

			public void WriteValue(string Section, string Key, string Value)
			{
				WritePrivateProfileString(Section, Key, Value, this.path);
			}

			public string ReadValue(string Section, string Key)
			{
				StringBuilder temp = new StringBuilder(255);
				int i = GetPrivateProfileString(Section, Key, "", temp,
												255, this.path);
				return temp.ToString();

			}
		}
	}
}
