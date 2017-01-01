using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using LSPD_First_Response.Mod.API;

namespace HornShouter
{
    public class Main : Plugin
    {
		public override void Initialize()
		{
			Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;

			for (int i = 0; i < 20; i++)
			{
				Game.LogTrivial("HORN SHOUTER LOADED!!! " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + " has been initialized.");
			}
		}

		public override void Finally()
		{
			//Cleanup!
			Game.LogTrivial("LSPDFR_API_Guide has been cleaned up.");
		}

		private static void OnOnDutyStateChangedHandler(bool OnDuty)
		{
			if (OnDuty)
			{
				StartHornShouter();
			}
		}

		private static void StartHornShouter()
		{
			Functions.PlayScannerAudio("LOL.mp3");
		}
	}
}
