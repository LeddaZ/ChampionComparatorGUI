using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ChampionComparatorGUI
{

    public static class Extra
	{
		private static string _patch;
		public static string GetPatch()
		{
			// Returns the latest patch number
			_patch = new StreamReader(WebRequest.Create("https://ddragon.leagueoflegends.com/api/versions.json").GetResponse().GetResponseStream()!).ReadToEnd().Split(',')[0].TrimStart('[').TrimStart('"').TrimEnd('"');
			return _patch;
		}

    }

    static class Program
    {
	    [STAThread] static void Main()
	    {
		    Application.SetHighDpiMode(HighDpiMode.SystemAware);
		    Application.EnableVisualStyles(); 
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Main());
	    }
	}
}
