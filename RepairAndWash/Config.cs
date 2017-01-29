// ****************************** Module Header ****************************** //
//
// Last Modified: 29:01:2017 / 16:40
// Creation: 03:01:2017
// Project: RepairAndWash
//
// <copyright file="Config.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

namespace RepairAndWash
{
	using System;
	using System.IO;
	using System.Windows.Forms;

	using FetzDeLib;

	internal class Config
	{
		public static void IniHandler()
		{
			INI.Path = "/Plugins/RepairAndWash.ini";

			if (!File.Exists(INI.Path))
			{
				INI.AddKey("KEYBINDINGS", "CleaningAndRepairing", "NumPad0");
				INI.AddKey("KEYBINDINGS", "Cleaning", "NumPad1");
				INI.AddKey("KEYBINDINGS", "Repairing", "NumPad2");
				INI.AddKey("KEYBINDINGS", "CleanPlayer", "NumPad3");
				INI.AddKey("SETTINGS", "NOTIFICATIONS", "true");
				INI.AddKey("SETTINGS", "PLAYSOUND", "true");
				INI.AddKey("SETTINGS", "AUTOUPDATE", "false");
				INI.AddKey("SETTINGS", "NOTIFICATIONTYPE", "top");
				INI.WriteData();
			}
			else
			{
				KeysConverter kc = new KeysConverter();
				string parserStep = "Not Started";

				try
				{
					parserStep = "CleanAndRepair KEY";
					object cleanAndRepair = kc.ConvertFromString(INI.Read("KEYBINDINGS", "CleaningAndRepairing"));
					if (cleanAndRepair != null)
					{
						global.KeyCleanAndRepair = (Keys)cleanAndRepair;
					}

					parserStep = "Clean KEY";
					object clean = kc.ConvertFromString(INI.Read("KEYBINDINGS", "Cleaning"));
					if (clean != null)
					{
						global.KeyClean = (Keys)clean;
					}

					parserStep = "Repair KEY";
					object repair = kc.ConvertFromString(INI.Read("KEYBINDINGS", "Repairing"));
					if (repair != null)
					{
						global.KeyRepair = (Keys)repair;
					}

					parserStep = "Notification KEY";
					string notificationsReader = INI.Read("SETTINGS", "NOTIFICATIONS");
					if (notificationsReader != null)
					{
						global.ShowNotifications = Convert.ToBoolean(notificationsReader);
					}

					parserStep = "Sound Setting";
					string playSoundReader = INI.Read("SETTINGS", "PLAYSOUND");
					if (playSoundReader != null)
					{
						global.isAudioEnables = Convert.ToBoolean(playSoundReader);
					}

					parserStep = "AutoUpdate Setting";
					string autoUpdateReader = INI.Read("SETTINGS", "AUTOUPDATE");
					if (autoUpdateReader != null)
					{
						global.AutoUpdate = Convert.ToBoolean(autoUpdateReader);
					}

					parserStep = "NOTIFICATIONTYPE Setting";
					string notificationTypeReader = INI.Read("SETTINGS", "NOTIFICATIONTYPE");
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
					object washPlayerKeyReader = kc.ConvertFromString(INI.Read("KEYBINDINGS", "CleanPlayer"));
					if (washPlayerKeyReader != null)
					{
						global.KeyCleanPlayer = (Keys)washPlayerKeyReader;
					}
				}
				catch (Exception)
				{
				}
			}
		}
	}
}