﻿// ****************************** Module Header ****************************** //
//
//
// Last Modified: 28:02:2017 / 23:34
// Creation: 28:02:2017
// Project: RepairAndWash
//
//
// <copyright file="Updater.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

namespace RepairAndWash.Core.Components
{
	using System;
	using System.Net;

	using RepairAndWash.Core.Common;

	internal static class Updater
	{
		private static readonly WebClient Web = new WebClient();

		public static void CheckUpdate()
		{
			string response = string.Empty;

			try
			{
				response = Web.DownloadStringTaskAsync(new Uri("https://raw.githubusercontent.com/FetzenRndy/RagePlugins/master/updater/RAWlatestVersion.txt")).Result;
			}
			catch (Exception)
			{
				// TODO : ErrorHandling in Updater
			}

			if (string.IsNullOrWhiteSpace(response))
			{
				return;
			}

			if (float.TryParse(response, out float result))
			{
				Global.Application.LatestVersion = result;
			}
		}
	}
}