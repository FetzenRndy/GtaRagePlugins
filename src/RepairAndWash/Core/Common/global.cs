// ****************************** Module Header ****************************** //
//
//
// Last Modified: 01:03:2017 / 00:07
// Creation: 28:02:2017
// Project: RepairAndWash
//
//
// <copyright file="global.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

namespace RepairAndWash.Core.Common
{
	using System.Media;
	using System.Windows.Forms;

	internal static class Global
	{
		/// <summary>
		/// Enumberations used in the Plugin
		/// </summary>
		public static class Enums
		{
			/// <summary>
			/// Action that can be Executed
			/// </summary>
			public enum Action
			{
				/// <summary>
				/// Repair Action
				/// </summary>
				Repair,

				/// <summary>
				/// Wash Action
				/// </summary>
				Wash,

				/// <summary>
				/// Repair and Wash Action
				/// </summary>
				RepairAndWash
			}
		}

		/// <summary>
		/// Settings and Info about the Plugin
		/// </summary>
		public static class Application
		{
			/// <summary>
			/// CurrentVersion of the Plugin
			/// </summary>
			public static float CurrentVersion { get; set; }
			/// <summary>
			/// Latest Version of the Plugin - Gets set by Downloading the version file forom Git
			/// </summary>
			public static float LatestVersion { get; set; }
			/// <summary>
			/// Bool to find out if the Plugin is starting for the First Time
			/// </summary>
			public static bool IsFirstStart { get; set; }
		}

		/// <summary>
		/// All Controls in the Plugin like Keybinds
		/// </summary>
		public static class Controls
		{
			/// <summary>
			/// Key for the Repair and Wash Action
			/// </summary>
			public static Keys RepairAndWash { get; set; }
			/// <summary>
			/// Key for the Wash Action
			/// </summary>
			public static Keys Wash { get; set; }
			/// <summary>
			/// Key for the Repair Action
			/// </summary>
			public static Keys Repair { get; set; }
		}

		/// <summary>
		/// All the Settings for the Userdefined Settings for the Plugin
		/// </summary>
		public static class Settings
		{
			/// <summary>
			/// Enum with all Possible Notification Types
			/// </summary>
			public enum NotificationType
			{
				/// <summary>
				/// The Help Notifications is positioned in the Top right Cornor of the Screen
				/// </summary>
				Help,

				/// <summary>
				/// The Radar Notification is above the Radar
				/// </summary>
				Radar,

				/// <summary>
				/// The Subtitle Notification displays a Subtitle
				/// </summary>
				Subtitle
			}

			/// <summary>
			/// Prefered Notification Type set in the INI
			/// </summary>
			public static NotificationType PreferedNotificationType { get; set; }
			/// <summary>
			/// Boolean to Enable and Disable Notifications - Set in the INI
			/// </summary>
			public static bool IsNotificationEnabled { get; set; }
			/// <summary>
			/// Boolean to set if the User wants the Audio - Set in the UI
			/// </summary>
			public static bool IsAudioEnabled { get; set; }
		}

		/// <summary>
		/// Sound Settings and Fields
		/// </summary>
		public static class Sound
		{
			/// <summary>
			/// Enum containing all Sounds
			/// </summary>
			public enum Sounds
			{
				/// <summary>
				/// Repair Sound
				/// </summary>
				Repair,

				/// <summary>
				/// Wash Sound
				/// </summary>
				Wash,

				/// <summary>
				/// Repair and Wash Soudn
				/// </summary>
				RepairAndWash
			}

			/// <summary>
			/// SoundPlayer with the Wash sound
			/// </summary>
			public static SoundPlayer WashSound { get; set; }
			/// <summary>
			/// SoundPlayer with the Repair Sound
			/// </summary>
			public static SoundPlayer RepairSound { get; set; }
		}
	}
}