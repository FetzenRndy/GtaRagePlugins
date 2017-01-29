// ****************************** Module Header ****************************** //
//
// Last Modified: 29:01:2017 / 15:49
// Creation: 29:01:2017
// Project: RepairAndWash
//
// <copyright file="util.cs" company="Patrick Hollweck" GitHub="https://github.com/FetzenRndy">//</copyright>
// *************************************************************************** //

namespace RepairAndWash
{
	using Rage;

	internal class Util
	{
		/// <summary>
		/// Displays a Notifications depending on the INI files configuration.
		/// </summary>
		/// <param name="type">Type of Notification</param>
		/// <param name="message">Message you want to Display</param>
		public static void DisplayNotificationType(global.NotificationType type, string message)
		{
			retry:

			if (global.ShowNotifications)
			{
				if (type == global.NotificationType.Help)
				{
					Game.DisplayHelp(message);
				}
				else if (type == global.NotificationType.Radar)
				{
					Game.DisplayNotification(message);
				}
				else if (type == global.NotificationType.Subtitle)
				{
					Game.DisplaySubtitle(message);
				}
				else
				{
					type = global.NotificationType.Help;
					goto retry;
				}
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

			// Get Type of the Vehicle.
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