// ****************************** Module Header ****************************** //
//
//
// Last Modified: 01:03:2017 / 01:20
// Creation: ::
// Project: RepairAndWash
//
//
// <copyright file="Updater.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

namespace RepairAndWash.Core.Components
{
	using RepairAndWash.Core.Common;
	using System;
	using System.Net;

	/// <summary>
	/// Class handling Updates and Downloading Potential Updates
	/// </summary>
	internal static class Updater
	{
		private static readonly WebClient Web = new WebClient();

		/// <summary>
		/// Checks for a Update by Downloading the LatestVersion from a maintained GitHub file
		/// </summary>
		public static void CheckUpdate()
		{
			string response = null;

			// Try to get the LatestVersion from a Git file
			try
			{
				response = Web.DownloadStringTaskAsync(new Uri("https://raw.githubusercontent.com/FetzenRndy/RagePlugins/master/updater/RAWlatestVersion.txt")).Result;
			}
			catch (Exception)
			{
				// TODO : ErrorHandling in Updater
			}

			// If the Response if NULL or empty the Download wasnt successfull -> Return
			if (string.IsNullOrWhiteSpace(response))
			{
				return;
			}

			// If the Plugin came so far the download was successfull and the Response can be parsed into a Float
			if (float.TryParse(response, out float result))
			{
				Global.Application.LatestVersion = result;
			}
		}
	}
}