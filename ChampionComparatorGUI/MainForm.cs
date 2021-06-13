using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Drawing;

namespace ChampionComparatorGUI
{
    public partial class Main : Form
    {
        public Main()
        {
			// Set the latest patch number on the corresponding label
            InitializeComponent();
            PatchLbl.Text += Extra.GetPatch();
        }

		private void BtnConfirm_Click(object sender, EventArgs e)
        {
			// Show champ names above the results when "Confirm" is clicked
            string ch1 = FirstChampTxt.Text;
            string ch2 = SecondChampTxt.Text;
			/* Store lowercase names in separate variables so I can show the
			 * original names in the form */
            string champ1 = ch1.ToLower().Contains("mundo") ? "DrMundo" : (ch1.ToLower().Contains("sol") ? "AurelionSol" : (ch1.ToLower().Contains("jarvan") ? "JarvanIV" : ((!ch1.ToLower().Equals("kai'sa") && !ch1.ToLower().Equals("kai sa")) ? (ch1.ToLower().Contains("kha") ? "Khazix" : (ch1.ToLower().Contains("kog") ? "KogMaw" : ((!ch1.ToLower().Equals("leesin") && !ch1.ToLower().Equals("lee sin")) ? (ch1.ToLower().Contains("master") ? "MasterYi" : (ch1.ToLower().Contains("miss") ? "MissFortune" : (ch1.ToLower().Contains("wukong") ? "MonkeyKing" : ((!ch1.ToLower().Equals("rek'sai") && !ch1.ToLower().Equals("reksai") && !ch1.ToLower().Equals("rek sai")) ? (ch1.ToLower().Contains("tahm") ? "TahmKench" : (ch1.ToLower().Contains("twisted") ? "TwistedFate" : ((ch1.ToLower().Equals("vel'koz") || ch1.ToLower().Equals("vel koz")) ? "Velkoz" : (ch1.ToLower().Contains("xin") ? "XinZhao" : (ch1.ToLower().Contains("pasquetto") ? "Shaco" : ((!ch1.Contains(" ")) ? (char.ToUpper(ch1[0]) + ch1.Substring(1).ToLower()) : (char.ToUpper(ch1[0]) + ch1.Substring(1).ToLower().TrimEnd(' ')))))))) : "RekSai")))) : "LeeSin"))) : "Kaisa")));
            string champ2 = ch2.ToLower().Contains("mundo") ? "DrMundo" : (ch2.ToLower().Contains("sol") ? "AurelionSol" : (ch2.ToLower().Contains("jarvan") ? "JarvanIV" : ((!ch2.ToLower().Equals("kai'sa") && !ch2.ToLower().Equals("kai sa")) ? (ch2.ToLower().Contains("kha") ? "Khazix" : (ch2.ToLower().Contains("kog") ? "KogMaw" : ((!ch2.ToLower().Equals("leesin") && !ch2.ToLower().Equals("lee sin")) ? (ch2.ToLower().Contains("master") ? "MasterYi" : (ch2.ToLower().Contains("miss") ? "MissFortune" : (ch2.ToLower().Contains("wukong") ? "MonkeyKing" : ((!ch2.ToLower().Equals("rek'sai") && !ch2.ToLower().Equals("reksai") && !ch2.ToLower().Equals("rek sai")) ? (ch2.ToLower().Contains("tahm") ? "TahmKench" : (ch2.ToLower().Contains("twisted") ? "TwistedFate" : ((ch2.ToLower().Equals("vel'koz") || ch2.ToLower().Equals("vel koz")) ? "Velkoz" : (ch2.ToLower().Contains("xin") ? "XinZhao" : (ch2.ToLower().Contains("pasquetto") ? "Shaco" : ((!ch2.Contains(" ")) ? (char.ToUpper(ch2[0]) + ch2.Substring(1).ToLower()) : (char.ToUpper(ch2[0]) + ch2.Substring(1).ToLower().TrimEnd(' ')))))))) : "RekSai")))) : "LeeSin"))) : "Kaisa")));

			// Get champ images and resize them so they fit in the PictureBoxes
			FirstChampPic.ImageLocation = "http://ddragon.leagueoflegends.com/cdn/" + Extra.GetPatch() + "/img/champion/" + champ1 + ".png";
			SecondChampPic.ImageLocation = "http://ddragon.leagueoflegends.com/cdn/" + Extra.GetPatch() + "/img/champion/" + champ2 + ".png";
			FirstChampPic.SizeMode = PictureBoxSizeMode.StretchImage;
			SecondChampPic.SizeMode = PictureBoxSizeMode.StretchImage;
			FirstChampPic.Visible = true;
			SecondChampPic.Visible = true;

			// Get data from LOL servers
			Champion1.Root root = JsonConvert.DeserializeObject<Champion1.Root>(new StreamReader(WebRequest.Create("http://ddragon.leagueoflegends.com/cdn/" + Extra.GetPatch() + "/data/en_US/champion/" + champ1 + ".json").GetResponse().GetResponseStream()).ReadToEnd());
			List<Champion1.Spell> spells = root.data[champ1].spells;
			Champion2.Root root2 = JsonConvert.DeserializeObject<Champion2.Root>(new StreamReader(WebRequest.Create("http://ddragon.leagueoflegends.com/cdn/" + Extra.GetPatch() + "/data/en_US/champion/" + champ2 + ".json").GetResponse().GetResponseStream()).ReadToEnd());
			List<Champion2.Spell> spells2 = root2.data[champ2].spells;

			if (root.data.TryGetValue(champ1, out var value) && root2.data.TryGetValue(champ2, out var value2))
			{
				// Set champion name labels and show them
				FirstChampResultsLbl.Text = value.name;
				FirstChampResultsLbl.Visible = true;
				SecondChampResultsLbl.Text = value2.name;
				SecondChampResultsLbl.Visible = true;

				// Q cooldown
				Champion1.Spell spell = spells[0];
				Champion2.Spell spell2 = spells2[0];
				// W cooldown
				Champion1.Spell spell3 = spells[1];
				Champion2.Spell spell4 = spells2[1];
				// E cooldown
				Champion1.Spell spell5 = spells[2];
				Champion2.Spell spell6 = spells2[2];
				// R cooldown
				Champion1.Spell spell7 = spells[3];
				Champion2.Spell spell8 = spells2[3];

				/* Store stats for both champs in a string array.
				 * I died inside to do this */
				string[] stats = new string[46];
				stats[0] = value.stats.hp.ToString();
				stats[1] = value2.stats.hp.ToString();
				stats[2] = "+" + value.stats.hpperlevel;
				stats[3] = "+" + value2.stats.hpperlevel;
				stats[4] = value.stats.hpregen.ToString();
				stats[5] = value2.stats.hpregen.ToString();
				stats[6] = "+" + value.stats.hpregenperlevel;
				stats[7] = "+" + value2.stats.hpregenperlevel;
				stats[8] = value.partype;
				stats[9] = value2.partype;
				stats[10] = value.stats.mp.ToString();
				stats[11] = value2.stats.mp.ToString();
				stats[12] = "+" + value.stats.mpperlevel;
				stats[13] = "+" + value2.stats.mpperlevel;
				stats[14] = value.stats.mpregen.ToString();
				stats[15] = value2.stats.mpregen.ToString();
				stats[16] = "+" + value.stats.mpregenperlevel;
				stats[17] = "+" + value2.stats.mpregenperlevel;
				stats[18] = value.stats.attackdamage.ToString();
				stats[19] = value2.stats.attackdamage.ToString();
				stats[20] = "+" + value.stats.attackdamageperlevel;
				stats[21] = "+" + value2.stats.attackdamageperlevel;
				stats[22] = value.stats.attackrange.ToString();
				stats[23] = value2.stats.attackrange.ToString();
				stats[24] = value.stats.attackspeed.ToString();
				stats[25] = value2.stats.attackspeed.ToString();
				stats[26] = "+" + value.stats.attackspeedperlevel + "%";
				stats[27] = "+" + value2.stats.attackspeedperlevel + "%";
				stats[28] = value.stats.armor.ToString();
				stats[29] = value2.stats.armor.ToString();
				stats[30] = "+" + value.stats.armorperlevel;
				stats[31] = "+" + value2.stats.armorperlevel;
				stats[32] = value.stats.spellblock.ToString();
				stats[33] = value2.stats.spellblock.ToString();
				stats[34] = "+" + value.stats.spellblockperlevel;
				stats[35] = "+" + value2.stats.spellblockperlevel;
				stats[36] = value.stats.movespeed.ToString();
				stats[37] = value2.stats.movespeed.ToString();
				stats[38] = spell.cooldownBurn;
				stats[39] = spell2.cooldownBurn;
				stats[40] = spell3.cooldownBurn;
				stats[41] = spell4.cooldownBurn;
				stats[42] = spell5.cooldownBurn;
				stats[43] = spell6.cooldownBurn;
				stats[44] = spell7.cooldownBurn;
				stats[45] = spell8.cooldownBurn;

                // Create an array to store stats labels
                System.Windows.Forms.Label[] labels = new System.Windows.Forms.Label[46];

				// Set every stat label and show it
				int i = 0;
				foreach (Control c in this.Controls)
				{
					if (c.Name.StartsWith("Res"))
					{
						labels[i] = (System.Windows.Forms.Label)c;
						labels[i].Visible = true;
						labels[i].Text = stats[i];
                        i++;
					}
				}
			}
		}

        private void DarkThemeBtn_Click(object sender, EventArgs e)
        {
			// Dark theme, a.k.a. the only good theme
			if (DarkThemeBtn.Text == "Dark theme")
            {
				this.BackColor = Color.FromArgb(19, 20, 20);
				foreach (Control c in this.Controls)
				{
					if (c.GetType() == typeof(System.Windows.Forms.Label))
					{
						c.ForeColor = Color.White;
					}
				}
				DarkThemeBtn.Text = "Light theme";
			}
			else
            {
				this.BackColor = DefaultBackColor;
				foreach (Control c in this.Controls)
				{
					if (c.GetType() == typeof(System.Windows.Forms.Label))
					{
						c.ForeColor = Color.Black;
					}
				}
				DarkThemeBtn.Text = "Dark theme";
			}
			
		}
	}
}
