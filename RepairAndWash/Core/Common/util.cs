// ****************************** Module Header ****************************** //
//
//
// Last Modified: 28:02:2017 / 15:15
// Creation: 28:02:2017
// Project: RepairAndWash
//
//
// <copyright file="util.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

namespace RepairAndWash.Core.Common
{
	using Rage;

	/// <summary>
	/// Util class with Helper Methodes
	/// </summary>
	internal static class Util
	{
		/// <summary>
		/// Displays a Notifications depending on the INI files configuration.
		/// </summary>
		/// <param name="message">Message you want to Display</param>
		public static void DisplayNotification(string message)
		{
			Game.DisplayNotification(message);
		}

		/// <summary>
		/// Gets The Vehicle Type as a String
		/// </summary>
		/// <param name="vehicle">Vehicle to Test</param>
		/// <returns>Vehicle type as string</returns>
		public static string GetVehicleType(Vehicle vehicle)
		{
			return vehicle.Class.ToString();
		}
	}
}