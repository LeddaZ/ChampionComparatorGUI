using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ChampionComparatorGUI
{

    public static class Extra
	{
		public static string patch;
		public static string GetPatch()
		{
			// Returns the latest patch number
			patch = new StreamReader(WebRequest.Create("https://ddragon.leagueoflegends.com/api/versions.json").GetResponse().GetResponseStream()).ReadToEnd().Split(',')[0].TrimStart('[').TrimStart('"').TrimEnd('"');
			return patch;
		}

    }

    static class Program
    {
		/* Ciao Netu
		 *       /\ I used his code */
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
			{
				Application.SetHighDpiMode(HighDpiMode.SystemAware);
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Main());
			}
		}
	}
