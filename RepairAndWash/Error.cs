using System;
using System.Collections.Generic;
using System.IO;
using Rage;

namespace RepairAndWash
{
	class Error
	{
		public static int errorCounter = 0;
		private static List<string> errorList = new List<string>();

		private static List<string> mainLog = new List<string>();

		public static void newError(string ErrorType, string CustomMessage, string errMessage = "none", string StackTrace = "none")
		{
			errorCounter++;
			errorList.Add(DateTime.Now + " === " + errorCounter + ": " + ErrorType +" -- " + CustomMessage + " /// " + errMessage + " :: " + StackTrace);
			mainLog.Add("ERROR: " + errorCounter);
		}

		public static void printErrorList()
		{
			newError("WRITTER", "WRITING ERRORLOG", "", "");
			File.WriteAllLines("Plugins/RAWErrorlog.txt", errorList);
			Game.LogTrivial("SUCCESS!");
		}

		public static void Log(string Sender ,string Message)
		{
			Game.LogTrivialDebug(Sender + " -- " + Message);
			mainLog.Add(DateTime.Now + " === " + Sender + " -- " + Message + "\n");
		}

		public static void printLog()
		{
			File.WriteAllLines("Plugins/RAWlog.txt", mainLog);
			Game.LogTrivial("SUCCESS!");
		}
	}
}
