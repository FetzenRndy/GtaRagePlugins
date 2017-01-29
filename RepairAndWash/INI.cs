// ****************************** Module Header ****************************** //
//
// Last Modified: 29:01:2017 / 02:12
// Creation: 03:01:2017
// Project: RepairAndWash
//
// <copyright file="INI.cs" company="Patrick Hollweck">//</copyright>
// *************************************************************************** //
namespace RepairAndWash
{
	using System;
	using System.IO;
	using System.Runtime.InteropServices;
	using System.Text;
	using System.Windows.Forms;

	using Rage;

	internal class INI
	{
		public static void IniHandler()
		{
			InIFile iniHandler = new InIFile { Path = "Plugins/RepairAndWash.ini" };

			if (!File.Exists(iniHandler.Path))
			{
				iniHandler.WriteValue("KEYBINDINGS", "CleaningAndRepairing", "NumPad0");
				iniHandler.WriteValue("KEYBINDINGS", "Cleaning", "NumPad1");
				iniHandler.WriteValue("KEYBINDINGS", "Repairing", "NumPad2");
				iniHandler.WriteValue("KEYBINDINGS", "CleanPlayer", "NumPad3");
				iniHandler.WriteValue("SETTINGS", "NOTIFICATIONS", "true");
				iniHandler.WriteValue("SETTINGS", "PLAYSOUND", "true");
				iniHandler.WriteValue("SETTINGS", "AUTOUPDATE", "false");
				iniHandler.WriteValue("SETTINGS", "NOTIFICATIONTYPE", "top");
			}
			else
			{
				KeysConverter kc = new KeysConverter();
				string parserStep = "Not Started";

				try
				{
					parserStep = "CleanAndRepair KEY";
					object cleanAndRepair = kc.ConvertFromString(iniHandler.ReadValue("KEYBINDINGS", "CleaningAndRepairing"));
					if (cleanAndRepair != null)
					{
						global.KeyCleanAndRepair = (Keys)cleanAndRepair;
					}

					parserStep = "Clean KEY";
					object clean = kc.ConvertFromString(iniHandler.ReadValue("KEYBINDINGS", "Cleaning"));
					if (clean != null)
					{
						global.KeyClean = (Keys)clean;
					}

					parserStep = "Repair KEY";
					object repair = kc.ConvertFromString(iniHandler.ReadValue("KEYBINDINGS", "Repairing"));
					if (repair != null)
					{
						global.KeyRepair = (Keys)repair;
					}

					parserStep = "Notification KEY";
					string notificationsReader = iniHandler.ReadValue("SETTINGS", "NOTIFICATIONS");
					if (notificationsReader != null)
					{
						global.ShowNotifications = Convert.ToBoolean(notificationsReader);
					}

					parserStep = "Sound Setting";
					string playSoundReader = iniHandler.ReadValue("SETTINGS", "PLAYSOUND");
					if (playSoundReader != null)
					{
						global.PlaySound = Convert.ToBoolean(playSoundReader);
					}

					parserStep = "AutoUpdate Setting";
					string autoUpdateReader = iniHandler.ReadValue("SETTINGS", "AUTOUPDATE");
					if (autoUpdateReader != null)
					{
						global.AutoUpdate = Convert.ToBoolean(autoUpdateReader);
					}

					parserStep = "NOTIFICATIONTYPE Setting";
					string notificationTypeReader = iniHandler.ReadValue("SETTINGS", "NOTIFICATIONTYPE");
					if (notificationTypeReader != null)
					{
						string temp = Convert.ToString(notificationTypeReader);

						if (temp == "top")
						{
							global.NotificationsType = global.NotificationType.Help;
						}
						else if (temp == "sub")
						{
							global.NotificationsType = global.NotificationType.Subtitle;
						}
						else if (temp == "radar")
						{
							global.NotificationsType = global.NotificationType.Radar;
						}
					}

					parserStep = "WASHPLAYER KEY";
					object washPlayerKeyReader = kc.ConvertFromString(iniHandler.ReadValue("KEYBINDINGS", "CleanPlayer"));
					if (washPlayerKeyReader != null)
					{
						global.KeyCleanPlayer = (Keys)washPlayerKeyReader;
					}
				}
				catch (Exception err)
				{
					Game.DisplaySubtitle(
						"~r~There was an error while Parsing the INI file at the Position: '" + parserStep
						+ "' Type into the Rage console: 'RAWWriteErrorLog' for a more detailed error Message - I will be stored in the Plugins folder of your GTA installation");
					Error.NewError("INI ERROR", "Error while Parsing the INI -" + parserStep, err.Message, err.StackTrace);
				}
			}
		}
	}

	// TODO: REPLACE WITH LIBRARY

	/// <summary>
	/// INI Files handling class
	/// </summary>
	internal class InIFile
	{
		public string Path { get; set; }

		public string ReadValue(string section, string key)
		{
			StringBuilder temp = new StringBuilder(255);
			GetPrivateProfileString(section, key, string.Empty, temp, 255, this.Path);
			return temp.ToString();
		}

		public void WriteValue(string section, string key, string value)
		{
			WritePrivateProfileString(section, key, value, this.Path);
		}

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(
			string section,
			string key,
			string def,
			StringBuilder retVal,
			int size,
			string filePath);

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
	}
}