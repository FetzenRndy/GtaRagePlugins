// ****************************** Module Header ****************************** //
//
//
// Last Modified: 28:02:2017 / 15:34
// Creation: 28:02:2017
// Project: RepairAndWash
//
//
// <copyright file="Audio.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

namespace RepairAndWash.Core.Components
{
	using System;
	using System.Media;

	using RepairAndWash.Core.Common;

	internal static class Audio
	{
		public static void Setup()
		{
			try
			{
				Global.Sound.RepairSound = new SoundPlayer("Plugins/RAW/repair.wav");
				Global.Sound.WashSound = new SoundPlayer("Plugins/RAW/clean.wav");
			}
			catch (Exception)
			{
				// TODO : ERROR HANDLING
			}
		}

		public static void PlaySound(Global.Sound.Sounds sound)
		{
			if (!Global.Settings.IsAudioEnabled)
			{
				return;
			}

			try
			{
				switch (sound)
				{
					case Global.Sound.Sounds.Repair:
						Global.Sound.RepairSound.Play();
						break;

					case Global.Sound.Sounds.Wash:
						Global.Sound.WashSound.Play();
						break;

					case Global.Sound.Sounds.RepairAndWash:
						Global.Sound.RepairSound.Play();
						break;
				}
			}
			catch (Exception)
			{
				// TODO : ErrorHandling
			}
		}
	}
}