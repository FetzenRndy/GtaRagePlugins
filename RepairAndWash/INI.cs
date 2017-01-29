using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Rage;

namespace RepairAndWash
{
	class INI
	{
		public static void IniHandler()
		{

			InIFile iniHandler = new InIFile { path = "Plugins/RepairAndWash.ini" };

			if (!File.Exists(iniHandler.path))
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
				string ParserStep = "Not Started";

				try
				{
					ParserStep = "CleanAndRepair KEY";
					object CleanAndRepair = kc.ConvertFromString(iniHandler.ReadValue("KEYBINDINGS", "CleaningAndRepairing"));
					if (CleanAndRepair != null)
					{
						global.KeyCleanAndRepair = (Keys)CleanAndRepair;
					}

					ParserStep = "Clean KEY";
					object Clean = kc.ConvertFromString(iniHandler.ReadValue("KEYBINDINGS", "Cleaning"));
					if (Clean != null)
					{
						global.KeyClean = (Keys)Clean;
					}

					ParserStep = "Repair KEY";
					object Repair = kc.ConvertFromString(iniHandler.ReadValue("KEYBINDINGS", "Repairing"));
					if (Repair != null)
					{
						global.KeyRepair = (Keys)Repair;
					}

					ParserStep = "Notification KEY";
					string NotificationsReader = iniHandler.ReadValue("SETTINGS", "NOTIFICATIONS");
					if (NotificationsReader != null)
					{
						global.ShowNotifications = Convert.ToBoolean(NotificationsReader);
					}

					ParserStep = "Sound Setting";
					string PlaySoundReader = iniHandler.ReadValue("SETTINGS", "PLAYSOUND");
					if (PlaySoundReader != null)
					{
						global.PlaySound = Convert.ToBoolean(PlaySoundReader);
					}

					ParserStep = "AutoUpdate Setting";
					string AutoUpdateReader = iniHandler.ReadValue("SETTINGS", "AUTOUPDATE");
					if (AutoUpdateReader != null)
					{
						global.AutoUpdate = Convert.ToBoolean(AutoUpdateReader);
					}

					ParserStep = "NOTIFICATIONTYPE Setting";
					string NotificationTypeReader = iniHandler.ReadValue("SETTINGS", "NOTIFICATIONTYPE");
					if (NotificationTypeReader != null)
					{
						global.NotificationsType = Convert.ToString(NotificationTypeReader);
					}

					ParserStep = "WASHPLAYER KEY";
					object WashPlayerKeyReader = kc.ConvertFromString(iniHandler.ReadValue("KEYBINDINGS", "CleanPlayer"));
					if (WashPlayerKeyReader != null)
					{
						global.KeyCleanPlayer = (Keys)WashPlayerKeyReader;
					}
				}
				catch (Exception err)
				{
					Game.DisplaySubtitle("~r~There was an error while Parsing the INI file at the Position: '" + ParserStep + "' Type into the Rage console: 'RAWWriteErrorLog' for a more detailed error Message - I will be stored in the Plugins folder of your GTA installation");
					Error.newError("INI ERROR", "Error while Parsing the INI -" + ParserStep , err.Message, err.StackTrace);
				}
			}
		}
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
			WritePrivateProfileString(Section, Key, Value, path);
		}

		public string ReadValue(string Section, string Key)
		{
			StringBuilder temp = new StringBuilder(255);
			GetPrivateProfileString(Section, Key, "", temp,
				255, path);
			return temp.ToString();

		}
	}
}
