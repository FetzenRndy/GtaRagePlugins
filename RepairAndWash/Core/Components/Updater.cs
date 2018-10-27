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
	using System;
	using System.Net;
	using System.Threading.Tasks;

	using RepairAndWash.Core.Common;
	using RepairAndWash.Core.Components.ErrorReporting;

	/// <summary>
	/// Class handling Updates and Downloading Potential Updates
	/// </summary>
	internal static class Updater
	{
		private const string UPDATE_URL = "https://raw.githubusercontent.com/FetzenRndy/RagePlugins/master/updater/RAWlatestVersion.txt";

		/// <summary>
		/// Checks for a Update by Downloading the LatestVersion from a maintained GitHub file
		/// </summary>
		public static async Task CheckUpdate()
		{
			string response = null;

			try
			{
				using (var Web = new WebClient())
				{
					response = await Web.DownloadStringTaskAsync(new Uri(UPDATE_URL));
				}
			}
			catch (Exception exception)
			{
				ErrorHandler.Report("Could not contact update service!", exception);
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