using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;

namespace RepairAndWash
{
	class global
	{
		public static string NotificationsType;
		public static string LatestVersion;
		public static string CurrentVersion = "1";
		public static bool AutoUpdate;
		public static int errors;
		public static Keys KeyCleanPlayer;
		public static Keys KeyCleanAndRepair;
		public static Keys KeyClean;
		public static Keys KeyRepair;
		public static bool ShowNotifications;
		public static bool PlaySound;
		public static SoundPlayer WashSound;
		public static SoundPlayer RepairSound;
	}
}
