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
		public static class Enums
		{
			public enum Action
			{
				Repair,
				Wash,
				RepairAndWash
			}
		}

		public static class Application
		{
			public static float CurrentVersion { get; set; }
			public static float LatestVersion { get; set; }
			public static bool IsFirstStart { get; set; }
		}

		public static class Controls
		{
			public static Keys RepairAndWash { get; set; }
			public static Keys Wash { get; set; }
			public static Keys Repair { get; set; }
		}

		public static class Settings
		{
			public enum NotificationType
			{
				Help,
				Radar,
				Subtitle
			}

			public static NotificationType PreferedNotificationType { get; set; }
			public static bool IsNotificationEnabled { get; set; }
			public static bool IsAudioEnabled { get; set; }
		}

		public static class Sound
		{
			public enum Sounds
			{
				Repair,
				Wash,
				RepairAndWash
			}

			public static SoundPlayer WashSound { get; set; }
			public static SoundPlayer RepairSound { get; set; }
		}
	}
}