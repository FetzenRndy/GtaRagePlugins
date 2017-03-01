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
		public static void DisplayNotificationType(string message)
		{
			// If the Notifications are Disabled via the INI return
			if (!Global.Settings.IsNotificationEnabled)
			{
				return;
			}

			// Find out about the PreferedNotificationType set in the INI and Display a Notification with its Type
			switch (Global.Settings.PreferedNotificationType)
			{
				case Global.Settings.NotificationType.Help:
					Game.DisplayHelp(message);
					break;

				case Global.Settings.NotificationType.Radar:
					Game.DisplayNotification(message);
					break;

				case Global.Settings.NotificationType.Subtitle:
					Game.DisplaySubtitle(message);
					break;

				default:
					Game.DisplayHelp($"{message} \n - There was no Notification Type set -> Using Default!");
					break;
			}
		}

		/// <summary>
		/// Gets The Vehicle Type as a String
		/// </summary>
		/// <param name="playerVehicle">Vehicle to Test</param>
		/// <returns>Vehicle type as string</returns>
		public static string GetVehicleType(Vehicle playerVehicle)
		{
			// Cycle over all Possible VehicleTypes provided by Rage and return it.
			if (playerVehicle.IsBicycle)
			{
				return "Bicycle";
			}
			else if (playerVehicle.IsPoliceVehicle)
			{
				return "Police Vehicle";
			}
			else if (playerVehicle.IsBig)
			{
				return "Truck / Bus / Plane";
			}
			else if (playerVehicle.IsBike)
			{
				return "Bike";
			}
			else if (playerVehicle.IsBlimp)
			{
				return "Blimp";
			}
			else if (playerVehicle.IsBoat)
			{
				return "Boat";
			}
			else if (playerVehicle.IsCar)
			{
				return "Car";
			}
			else if (playerVehicle.IsHelicopter)
			{
				return "Helicopter";
			}
			else if (playerVehicle.IsPlane)
			{
				return "Plane";
			}
			else if (playerVehicle.IsQuadBike)
			{
				return "QuadBike";
			}
			else if (playerVehicle.IsSubmarine)
			{
				return "Submarine";
			}
			else if (playerVehicle.IsTrain)
			{
				return "Train";
			}
			else
			{
				return "Vehicle";
			}
		}
	}
}