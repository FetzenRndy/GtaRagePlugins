using System;
using System.Collections.Generic;

namespace RepairAndWash.Core.Components.ErrorReporting.Reporters
{
	public static class ErrorHandler
	{
		private static List<IErrorReporter> reporters = new List<IErrorReporter>();

		public static void RegisterReporter(IErrorReporter reporter)
		{
			reporters.Add(reporter);
		}

		public static void Report(string message)
		{
			InvokeHandlers(message);
		}

		public static void Report(Exception exception)
		{
			InvokeHandlers(FormatException(exception));
		}

		public static void Report(string message, Exception exception)
		{
			InvokeHandlers($"{message} \n\n {FormatException(exception)}");
		}

		private static string FormatException(Exception exception)
		{
			return $"-- ERROR -- \n {exception.Message}";
		}

		private static void InvokeHandlers(string message)
		{
			foreach (var reporter in reporters)
			{
				reporter.Report(message);
			}
		}
	}
}