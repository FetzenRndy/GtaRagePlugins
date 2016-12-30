using Rage;

[assembly: Rage.Attributes.Plugin("RepairAndWash", Description = "Repairs and Washes your Car on KeyPress", Author = "Patrick Hollweck")]

/*
 * Developed by Patrick Hollweck - GitHub: https://github.com/FetzenRndy;
 * This Plugin makes washing and repairing your car simpler than ever before.
 */

namespace RepairAndWash
{
	public class EntryPoint
	{
		public static void Main()
		{
			WaitForActivation();

			Game.DisplayNotification("Repair and Wash - Loaded!");
			Game.LogTrivial("Repair and Wash - Loaded!");
		}

		/// <summary>
		/// Sets up a new GameFibre and wait for Activation of the Key. Then call the OnActivation function
		/// </summary>
		public static void WaitForActivation()
		{
			Game.LogTrivial("Repair and Wash - Waiting for Activation");
			GameFiber.StartNew(delegate
			{
				while (true)
				{
					GameFiber.Yield();

					if (Game.IsKeyDown(System.Windows.Forms.Keys.NumPad0))
					{
						break;
					}

					Game.LogTrivial("Repair and Wash KEYDOWN!");
				}

				OnActivation();
			});

			GameFiber.Hibernate();
		}

		/// <summary>
		/// Get player and their vehicle, If Player is inside a Vehicle clean and repair it, Then start a new GameFibre.
		/// </summary>
		public static void OnActivation()
		{
			Ped player = Game.LocalPlayer.Character;
			Vehicle playerVehicle = player.CurrentVehicle;

			if (playerVehicle != null)
			{
				playerVehicle.Repair();
				playerVehicle.Wash();

				Game.LogTrivial("Repair and Wash - Repaired and washed");
				Game.DisplayNotification("Repaired and cleaned your car!");
			}
			else
			{
				Game.DisplayNotification("You are not in a Vehicle...");
			}

			WaitForActivation();
		}
	}
}
