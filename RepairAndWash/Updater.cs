using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using Rage;

namespace RepairAndWash
{
	//TODO: REWRITE
	class Updater
	{
		public static async void GetVersionAsync()
		{
			global.LatestVersion = await new WebClient().DownloadStringTaskAsync("https://raw.githubusercontent.com/FetzenRndy/RagePlugins/master/updater/RAWlatestVersion.txt");
		}

		public static async Task<bool> DownloadUpdate()
		{
			await new WebClient().DownloadFileTaskAsync
			(
				new Uri("https://github.com/FetzenRndy/RagePlugins/blob/master/RepairAndWash/Releases/" + global.LatestVersion + ".rar?raw=true"),
				"Plugins/RAWUpdate" + global.LatestVersion + ".rar"
			);

			return true;
		}

		/// <summary>
		/// Handles the Updates
		/// </summary>
		public static void Update()
		{
			try
			{
				WebClient wc = new WebClient();

				if (global.LatestVersion != "")
				{
					if (global.LatestVersion != global.CurrentVersion)
					{
						Game.DisplayNotification("~y~Version " + global.LatestVersion + "of RepairAndWash is out, Please Update");
					}

					if (global.AutoUpdate)
					{
						//TODO TEST
						DownloadUpdate().Start();
						Game.DisplayNotification("~g~DOWNLOADING...");

						wc.DownloadFileCompleted += (sender, e) =>
						{
							Game.DisplayNotification("Download Completed");

							try
							{
								//TODO: Rethink...
								File.Delete("Plugins/RepairAndWash.ini");
								File.Delete("Plugins/RepairAndWash.dll");
								ZipFile.ExtractToDirectory("Plugins/RAWUpdate" + global.LatestVersion + ".rar", "Plugins/");
								Game.DisplayNotification("~g~Update Completed!");
								File.Delete("Plugins/RAWUpdate" + global.LatestVersion + ".rar");
								Game.DisplayNotification("~y~PLEASE RESTART YOUR GAME!");
							}
							catch (Exception err)
							{
								//global.errorList.Add("UPDATE ERROR: ZIP: " + err.Message + "        " + err.StackTrace);
								Game.DisplayNotification("~r~ERROR While extracting the .rar! Please manually extract it  and Restart the Game");
							}
						};
					}
				}
			}
			catch (Exception err)
			{
				global.errors++;
				//global.errorList.Add("Updater ERROR: " + err.Message + "      " + err.StackTrace);
			}

		}
	}
}
