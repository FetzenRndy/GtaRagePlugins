using System.Runtime.InteropServices;
using System.Text;
using Rage;

[assembly: Rage.Attributes.Plugin("HornShouter", Description = "Let's your Police Car make the 'POLICE STOP' sound", Author = "Patrick Hollweck")]

/*
 * Developed by Patrick Hollweck - GitHub: https://github.com/FetzenRndy;
 * This Plugin will make your Police car be able to shout the Police spcific sounds like "POLICE STOP" , "STOP YOUR VEHICLE" while in Pursuit.
 */



namespace HornShouter
{
	public class EntryPoint
	{
		public static void Main()
		{
			StartPlugin();
			Game.DisplayNotification("~b~Horn Shouter ~w~ Has been loaded ~g~Successfully.");
		}

		public static void StartPlugin()
		{
			while (true)
			{
				
			}
		}




		/// <summary>
		/// INI Files handling class
		/// </summary>
		class InIFile
		{
			public string path;

			[DllImport("kernel32")]
			private static extern long WritePrivateProfileString(string section,
			string key, string val, string filePath);

			[DllImport("kernel32")]
			private static extern int GetPrivateProfileString(string section,
			string key, string def, StringBuilder retVal,
			int size, string filePath);

			public void WriteValue(string Section, string Key, string Value)
			{
				WritePrivateProfileString(Section, Key, Value, path);
			}

			public string ReadValue(string Section, string Key)
			{
				StringBuilder temp = new StringBuilder(255);
				GetPrivateProfileString(Section, Key, "", temp,
					255, path);
				return temp.ToString();

			}
		}
	}
}
