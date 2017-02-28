// ****************************** Module Header ****************************** //
//
//
// Last Modified: 28:02:2017 / 17:38
// Creation: 28:02:2017
// Project: RepairAndWash
//
//
// <copyright file="SettingsForm.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

namespace RepairAndWash.Forms
{
	using System;
	using System.Windows.Forms;

	using Rage;

	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Game.LogTrivial("CLICK!!!");
		}

		private void label37_Click(object sender, EventArgs e)
		{

		}
	}
}