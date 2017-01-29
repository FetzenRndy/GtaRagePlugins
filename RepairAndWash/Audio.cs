// ****************************** Module Header ****************************** //
//
// Last Modified: 29:01:2017 / 16:04
// Creation: 29:01:2017
// Project: RepairAndWash
//
// <copyright file="Audio.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

namespace RepairAndWash
{
	using System;
	using System.Media;

	internal class Audio
	{
		public static void Setup()
		{
			try
			{
				global.RepairSound = new SoundPlayer("Plugins/RAW/repair.wav");
				global.WashSound = new SoundPlayer("Plugins/RAW/clean.wav");
			}
			catch (Exception)
			{
				// TODO : ERROR HANDLING
			}
		}
	}
}