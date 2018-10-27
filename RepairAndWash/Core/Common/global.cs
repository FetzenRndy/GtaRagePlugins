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
	using System.Windows.Forms;

	internal static class Global
	{
		// TODO: Take the Global.Enums.Action enum out and refactor commands into seperate module.

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
	}
}