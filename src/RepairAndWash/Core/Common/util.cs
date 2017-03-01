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

namespace RepairAndWash
{
	using Rage;

	using RepairAndWash.Core.Common;

	internal class Util
	{
		/// <summary>
		/// Displays a Notifications depending on the INI files configuration.
		/// </summary>
		/// <param name="message">Message you want to Display</param>
		public static void DisplayNotificationType(string message)
		{
			if (!Global.Settings.IsNotificationEnabled)
			{
				return;
			}

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
			string playerVehicleType;

			if (playerVehicle.IsBicycle)
			{
				playerVehicleType = "Bicycle";
			}
			else if (playerVehicle.IsPoliceVehicle)
			{
				playerVehicleType = "Police Vehicle";
			}
			else if (playerVehicle.IsBig)
			{
				playerVehicleType = "Truck / Bus / Plane";
			}
			else if (playerVehicle.IsBike)
			{
				playerVehicleType = "Bike";
			}
			else if (playerVehicle.IsBlimp)
			{
				playerVehicleType = "Blimp";
			}
			else if (playerVehicle.IsBoat)
			{
				playerVehicleType = "Boat";
			}
			else if (playerVehicle.IsCar)
			{
				playerVehicleType = "Car";
			}
			else if (playerVehicle.IsHelicopter)
			{
				playerVehicleType = "Helicopter";
			}
			else if (playerVehicle.IsPlane)
			{
				playerVehicleType = "Plane";
			}
			else if (playerVehicle.IsQuadBike)
			{
				playerVehicleType = "QuadBike";
			}
			else if (playerVehicle.IsSubmarine)
			{
				playerVehicleType = "Submarine";
			}
			else if (playerVehicle.IsTrain)
			{
				playerVehicleType = "Train";
			}
			else
			{
				playerVehicleType = "Vehicle";
			}

			return playerVehicleType;
		}
	}
}