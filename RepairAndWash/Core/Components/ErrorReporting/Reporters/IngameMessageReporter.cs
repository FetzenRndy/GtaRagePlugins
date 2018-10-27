using Rage;

namespace RepairAndWash.Core.Components.ErrorReporting.Reporters
{
	public class IngameMessageReporter : IErrorReporter
	{
		public void Report(string message)
		{
			Game.DisplayNotification("RAW Error: " + message);
		}
	}
}