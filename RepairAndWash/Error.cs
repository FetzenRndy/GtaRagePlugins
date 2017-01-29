// ****************************** Module Header ****************************** //
//
// Last Modified: 29:01:2017 / 02:12
// Creation: 03:01:2017
// Project: RepairAndWash
//
// <copyright file="Error.cs" company="Patrick Hollweck">//</copyright>
// *************************************************************************** //
namespace RepairAndWash
{
	using System;
	using System.Collections.Generic;
	using System.IO;

	using Rage;

	internal class Error
	{
		private static readonly List<string> errorList = new List<string>();

		private static readonly List<string> mainLog = new List<string>();

		public static int errorCounter { get; set; } = 0;

		public static void Log(string sender, string message)
		{
			Game.LogTrivialDebug(sender + " -- " + message);
			mainLog.Add(DateTime.Now + " === " + sender + " -- " + message + "\n");
		}

		public static void NewError(
			string errorType,
			string customMessage,
			string errMessage = "none",
			string stackTrace = "none")
		{
			errorCounter++;
			errorList.Add(
				DateTime.Now + " === " + errorCounter + ": " + errorType + " -- " + customMessage + " /// " + errMessage + " :: "
				+ stackTrace);
			mainLog.Add("ERROR: " + errorCounter);
		}

		public static void PrintErrorList()
		{
			NewError("WRITTER", "WRITING ERRORLOG", string.Empty, string.Empty);
			File.WriteAllLines("Plugins/RAWErrorlog.txt", errorList);
			Game.LogTrivial("SUCCESS!");
		}

		public static void PrintLog()
		{
			File.WriteAllLines("Plugins/RAWlog.txt", mainLog);
			Game.LogTrivial("SUCCESS!");
		}
	}
}