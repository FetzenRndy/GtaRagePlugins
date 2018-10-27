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
	using RepairAndWash.Core.Common;
	using System;
	using System.Media;

	/// <summary>
	/// Class Handling Audio Output
	/// </summary>
	internal static class Audio
	{
		/// <summary>
		/// Try's to set up the AudioPlayers for the various Sounds
		/// </summary>
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

		/// <summary>
		/// Try's to Play a given Sound if not Disabled via the INI
		/// </summary>
		/// <param name="sound">Sound that Should be Played</param>
		public static void PlaySound(Global.Sound.Sounds sound)
		{
			// If its Disabled in the INI return and Play no Sound
			if (!Global.Settings.IsAudioEnabled)
			{
				return;
			}

			try
			{
				// Try to play The sound given in the Argument via the SoundPlayers from Global.Sound
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
				// TODO : ErrorHandling in Audio.PlaySound
			}
		}
	}
}