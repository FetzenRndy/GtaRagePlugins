// ****************************** Module Header ****************************** //
//
//
// Last Modified: 01:03:2017 / 00:51
// Creation: 28:02:2017
// Project: RepairAndWash
//
//
// <copyright file="Config.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

namespace RepairAndWash.Core.Components
{
	using Rage.Forms;

	/// <summary>
	/// Class containing all Logic for Reading and Writing the Configuration ( Even with a Ingame UI!!11!!1)
	/// </summary>
	public static class Config
	{
		/// <summary>
		/// Set's all Values from the INI to their Variables
		/// </summary>
		public static void Setup()
		{
			// If the PLugin starts for the First Time start a Nice litte Ingame GUI that allows for ez Configuration
			if (Properties.Settings.Default.IsFirstStart)
			{
				OpenConfigDialog();
			}

			// TODO : INI
		}

		/// <summary>
		/// Little ingame GUI for ez Configuration
		/// </summary>
		private static void OpenConfigDialog()
		{
			GwenForm form = new GwenForm(typeof(Forms.SettingsForm));

			form.InitializeLayout();
			form.Show();
		}
	}
}