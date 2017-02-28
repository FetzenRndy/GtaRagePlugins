// ****************************** Module Header ****************************** //
//
//
// Last Modified: 28:02:2017 / 15:34
// Creation: 28:02:2017
// Project: RepairAndWash
//
//
// <copyright file="Updater.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

namespace RepairAndWash
{
	using System;
	using System.Net;

	using RepairAndWash.Core.Common;

	internal static class Updater
	{
		public static WebClient web = new WebClient();

		public static void CheckUpdate()
		{
			string response = string.Empty;

			try
			{
				response = web.DownloadStringTaskAsync(new Uri("https://raw.githubusercontent.com/FetzenRndy/RagePlugins/master/updater/RAWlatestVersion.txt")).Result;
			}
			catch (Exception)
			{
				// TODO : ErrorHandling
			}

			if (string.IsNullOrWhiteSpace(response))
			{
			}
			else if (float.TryParse(response, out float result))
			{
				Global.Application.LatestVersion = result;
			}
		}
	}
}