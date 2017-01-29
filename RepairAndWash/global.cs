// ****************************** Module Header ****************************** //
//
// Last Modified: 29:01:2017 / 02:07
// Creation: 03:01:2017
// Project: RepairAndWash
//
// <copyright file="global.cs" company="Patrick Hollweck">//</copyright>
// *************************************************************************** //
namespace RepairAndWash
{
	using System.Media;
	using System.Windows.Forms;

	internal class global
	{
		/// <summary>
		/// Describes all the Posible Notification Types
		/// </summary>
		public enum NotificationType
		{
			/// <summary>
			/// Top of the Screen Help Notification
			/// </summary>
			Help,

			/// <summary>
			/// Above the Minimap Notifiaction
			/// </summary>
			Radar,

			/// <summary>
			/// Subtitle Notification
			/// </summary>
			Subtitle
		}

		public static bool AutoUpdate { get; set; }

		public static string CurrentVersion { get; set; } = "1";

		public static int Errors { get; set; }

		public static Keys KeyClean { get; set; }

		public static Keys KeyCleanAndRepair { get; set; }

		public static Keys KeyCleanPlayer { get; set; }

		public static Keys KeyRepair { get; set; }

		public static string LatestVersion { get; set; }

		public static NotificationType NotificationsType { get; set; }

		public static bool isAudioEnables { get; set; }

		public static SoundPlayer RepairSound { get; set; }

		public static bool ShowNotifications { get; set; }

		public static SoundPlayer WashSound { get; set; }
	}
}