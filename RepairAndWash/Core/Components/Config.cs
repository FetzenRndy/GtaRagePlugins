// ****************************** Module Header ****************************** //
//
//
// Last Modified: 28:02:2017 / 16:12
// Creation: 28:02:2017
// Project: RepairAndWash
//
//
// <copyright file="Config.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

namespace RepairAndWash.Core.Components
{
	using Rage.Forms;

	public static class Config
	{
		public static void Setup()
		{
			if (Properties.Settings.Default.IsFirstStart)
			{
				OpenConfigDialog();
			}
		}

		private static void OpenConfigDialog()
		{
			GwenForm form = new GwenForm("RepairAndWash Configuration", 500, 500);
			form.Show();
		}
	}
}