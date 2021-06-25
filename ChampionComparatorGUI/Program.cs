using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ChampionComparatorGUI
{

    public static class Extra
    {
        private static string _patch;
        private static PrivateFontCollection customFont = new();
        public static string GetPatch()
        {
            // Returns the latest patch number
            _patch = new StreamReader(WebRequest.Create("https://ddragon.leagueoflegends.com/api/versions.json").GetResponse().GetResponseStream()!).ReadToEnd().Split(',')[0].TrimStart('[').TrimStart('"').TrimEnd('"');
            return _patch;
        }
        //Sets the font for every Control
        public static void UseCustomFont(string name, int size, Control control)
        {
            customFont.AddFontFile(@".\Resources\Karla-VariableFont_wght.ttf");
            if (control.Name.Equals("FirstChampResultsLbl") || control.Name.Equals("SecondChampResultsLbl"))
            {
                control.Font = new Font(customFont.Families[1], size, FontStyle.Bold | FontStyle.Underline);
            }
            else if (control.Name.Equals("FirstChampLbl") || control.Name.Equals("SecondChampLbl") || control.Name.Equals("BtnConfirm") || control.Name.Equals("DarkThemeBtn") || control.Name.Equals("PatchLbl") || control.Name.Equals("HPStatsLbl") || control.Name.Equals("ManaStatsLbl") || control.Name.Equals("AtkStatsLbl") || control.Name.Equals("ArmorStatsLbl") || control.Name.Equals("MagicStatsLbl") || control.Name.Equals("CoolStatsLbl"))
            {
                control.Font = new Font(customFont.Families[1], size, FontStyle.Bold);
            }
            else
            {
                control.Font = new Font(customFont.Families[0], size, FontStyle.Bold);
            }
        }

    }

    static class Program
    {
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
