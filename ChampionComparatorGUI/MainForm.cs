using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;

namespace ChampionComparatorGUI
{
	public partial class Main : Form
	{
		int _z;

		public Main()
		{
			InitializeComponent();
		}

		public void BtnConfirm_Click(object sender, EventArgs e)
		{
			// Show champ names above the results when "Confirm" is clicked
			string ch1 = FirstChampTxt.Text;
			string ch2 = SecondChampTxt.Text;
			/* Store lowercase names in separate variables so I can show the
			 * original names in the form */
			
			string champ1 = ch1.ToLower().Contains("mundo") ? "DrMundo" : (ch1.ToLower().Contains("sol") ? "AurelionSol" : (ch1.ToLower().Contains("jarvan")? "JarvanIV" : ((!ch1.ToLower().Equals("kai'sa") && !ch1.ToLower().Equals("kai sa")) ? (ch1.ToLower().Contains("kha") ? "Khazix" : (ch1.ToLower().Contains("kog") ? "KogMaw" : ((!ch1.ToLower().Equals("leesin") && !ch1.ToLower().Equals("lee sin")) ? (ch1.ToLower().Contains("master") ? "MasterYi" : (ch1.ToLower().Contains("miss") ? "MissFortune" : (ch1.ToLower().Contains("wukong") ? "MonkeyKing" : ((!ch1.ToLower().Equals("rek'sai") && !ch1.ToLower().Equals("reksai") && !ch1.ToLower().Equals("rek sai")) ? (ch1.ToLower().Contains("tahm") ? "TahmKench" : (ch1.ToLower().Contains("twisted") ? "TwistedFate" : ((ch1.ToLower().Equals("vel'koz") || ch1.ToLower().Equals("vel koz")) ? "Velkoz" : (ch1.ToLower().Contains("xin") ? "XinZhao" : (ch1.ToLower().Contains("pasquetto") ? "Shaco" : ((!ch1.Contains(" ")) ? (char.ToUpper(ch1[0]) + ch1.Substring(1).ToLower()) : (char.ToUpper(ch1[0]) + ch1.Substring(1).ToLower().TrimEnd(' ')))))))) : "RekSai")))) : "LeeSin"))) : "Kaisa")));
			string champ2 = ch2.ToLower().Contains("mundo") ? "DrMundo" : (ch2.ToLower().Contains("sol") ? "AurelionSol" : (ch2.ToLower().Contains("jarvan")? "JarvanIV" : ((!ch2.ToLower().Equals("kai'sa") && !ch2.ToLower().Equals("kai sa")) ? (ch2.ToLower().Contains("kha") ? "Khazix" : (ch2.ToLower().Contains("kog") ? "KogMaw" : ((!ch2.ToLower().Equals("leesin") && !ch2.ToLower().Equals("lee sin")) ? (ch2.ToLower().Contains("master") ? "MasterYi" : (ch2.ToLower().Contains("miss") ? "MissFortune" : (ch2.ToLower().Contains("wukong") ? "MonkeyKing" : ((!ch2.ToLower().Equals("rek'sai") && !ch2.ToLower().Equals("reksai") && !ch2.ToLower().Equals("rek sai")) ? (ch2.ToLower().Contains("tahm") ? "TahmKench" : (ch2.ToLower().Contains("twisted") ? "TwistedFate" : ((ch2.ToLower().Equals("vel'koz") || ch2.ToLower().Equals("vel koz")) ? "Velkoz" : (ch2.ToLower().Contains("xin") ? "XinZhao" : (ch2.ToLower().Contains("pasquetto") ? "Shaco" : ((!ch2.Contains(" ")) ? (char.ToUpper(ch2[0]) + ch2.Substring(1).ToLower()) : (char.ToUpper(ch2[0]) + ch2.Substring(1).ToLower().TrimEnd(' ')))))))) : "RekSai")))) : "LeeSin"))) : "Kaisa")));

			// Get champ images and resize them so they fit in the PictureBoxes
			FirstChampPic.ImageLocation = $@"http://ddragon.leagueoflegends.com/cdn/{Extra.GetPatch()}/img/champion/{champ1}.png";
			SecondChampPic.ImageLocation = $@"http://ddragon.leagueoflegends.com/cdn/{Extra.GetPatch()}/img/champion/{champ2}.png";
			FirstChampPic.SizeMode = PictureBoxSizeMode.StretchImage;
			SecondChampPic.SizeMode = PictureBoxSizeMode.StretchImage;
			FirstChampPic.Visible = true;
			SecondChampPic.Visible = true;

			// Get data from LOL servers
			Champion1.Root requestChampion1 = JsonConvert.DeserializeObject<Champion1.Root>(new StreamReader(WebRequest.Create($"http://ddragon.leagueoflegends.com/cdn/{Extra.GetPatch()}/data/en_US/champion/{champ1}.json").GetResponse().GetResponseStream()!).ReadToEnd());
			List<Champion1.Spell> spells = requestChampion1?.data[champ1].spells;
			Champion2.Root requestChampion2 = JsonConvert.DeserializeObject<Champion2.Root>(new StreamReader(WebRequest.Create($"http://ddragon.leagueoflegends.com/cdn/{Extra.GetPatch()}/data/en_US/champion/{champ2}.json").GetResponse().GetResponseStream()!).ReadToEnd());
			List<Champion2.Spell> spells2 = requestChampion2?.data[champ2].spells;

			if (requestChampion2 != null && requestChampion1 != null && requestChampion1.data.TryGetValue(champ1, out var champion1) && requestChampion2.data.TryGetValue(champ2, out var champion2))
			{
				// Set champion name labels and show them
				FirstChampResultsLbl.Text = champion1.name;
				FirstChampResultsLbl.Visible = true;
				SecondChampResultsLbl.Text = champion2.name;
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

				// Store stats for both champs in a string array. I died inside to do this.
				string[] stats = new string[46];
				stats[0] = champion1.stats.hp.ToString(CultureInfo.InvariantCulture);
				stats[1] = champion2.stats.hp.ToString(CultureInfo.InvariantCulture);
				stats[2] = $"+{champion1.stats.hpperlevel}";
				stats[3] = $"+{champion2.stats.hpperlevel}";
				stats[4] = champion1.stats.hpregen.ToString(CultureInfo.InvariantCulture);
				stats[5] = champion2.stats.hpregen.ToString(CultureInfo.InvariantCulture);
				stats[6] = $"+{champion1.stats.hpregenperlevel}";
				stats[7] = $"+{champion2.stats.hpregenperlevel}";
				stats[8] = champion1.partype;
				stats[9] = champion2.partype;
				stats[10] = champion1.stats.mp.ToString(CultureInfo.InvariantCulture);
				stats[11] = champion2.stats.mp.ToString(CultureInfo.InvariantCulture);
				stats[12] = $"+{champion1.stats.mpperlevel}";
				stats[13] = $"+{champion2.stats.mpperlevel}";
				stats[14] = champion1.stats.mpregen.ToString(CultureInfo.InvariantCulture);
				stats[15] = champion2.stats.mpregen.ToString(CultureInfo.InvariantCulture);
				stats[16] = $"+{champion1.stats.mpregenperlevel}";
				stats[17] = $"+{champion2.stats.mpregenperlevel}";
				stats[18] = champion1.stats.attackdamage.ToString(CultureInfo.InvariantCulture);
				stats[19] = champion2.stats.attackdamage.ToString(CultureInfo.InvariantCulture);
				stats[20] = $"+{champion1.stats.attackdamageperlevel}";
				stats[21] = $"+{champion2.stats.attackdamageperlevel}";
				stats[22] = champion1.stats.attackrange.ToString(CultureInfo.InvariantCulture);
				stats[23] = champion2.stats.attackrange.ToString(CultureInfo.InvariantCulture);
				stats[24] = champion1.stats.attackspeed.ToString(CultureInfo.InvariantCulture);
				stats[25] = champion2.stats.attackspeed.ToString(CultureInfo.InvariantCulture);
				stats[26] = $"{champion1.stats.attackspeedperlevel}%";
				stats[27] = $"{champion2.stats.attackspeedperlevel}%";
				stats[28] = champion1.stats.armor.ToString(CultureInfo.InvariantCulture);
				stats[29] = champion2.stats.armor.ToString(CultureInfo.InvariantCulture);
				stats[30] = $"+{champion1.stats.armorperlevel}";
				stats[31] = $"+{champion2.stats.armorperlevel}";
				stats[32] = champion1.stats.spellblock.ToString(CultureInfo.InvariantCulture);
				stats[33] = champion2.stats.spellblock.ToString(CultureInfo.InvariantCulture);
				stats[34] = $"+{champion1.stats.spellblockperlevel}";
				stats[35] = $"+{champion2.stats.spellblockperlevel}";
				stats[36] = champion1.stats.movespeed.ToString(CultureInfo.InvariantCulture);
				stats[37] = champion2.stats.movespeed.ToString(CultureInfo.InvariantCulture);
				stats[38] = spell.cooldownBurn;
				stats[39] = spell2.cooldownBurn;
				stats[40] = spell3.cooldownBurn;
				stats[41] = spell4.cooldownBurn;
				stats[42] = spell5.cooldownBurn;
				stats[43] = spell6.cooldownBurn;
				stats[44] = spell7.cooldownBurn;
				stats[45] = spell8.cooldownBurn;
				
				// Create an array to store stats labels
				Label[] labels = new Label[46];

				// Set every stat label and show it
				int i = 0;
				foreach (Control c in this.Controls)
				{
					if (c.Name.StartsWith("Res"))
					{
						labels[i] = (Label) c;
						labels[i].Visible = true;
						labels[i].Text = stats[i];
						i++;
					}
				}
				
				// Set the colors of the most important stats. Netu died inside to do this.
				if (champion1.stats.hp > champion2.stats.hp)
				{
					Res1.ForeColor = Color.Green;
					Res2.ForeColor = Color.Red;
				}
				else if (champion1.stats.hp == champion2.stats.hp)
				{
					Res1.ForeColor = Color.Blue;
					Res2.ForeColor = Color.Blue;
				}
				else
				{
					Res2.ForeColor = Color.Green;
					Res1.ForeColor = Color.Red;
				}

				if (champion1.partype == champion2.partype)
				{
					if (champion1.stats.mp > champion2.stats.mp)
					{
						Res11.ForeColor = Color.Green;
						Res12.ForeColor = Color.Red;
					}
					else if (champion1.stats.mp == champion2.stats.mp)
					{
						Res11.ForeColor = Color.Blue;
						Res12.ForeColor = Color.Blue;
					}
					else
					{
						Res12.ForeColor = Color.Green;
						Res11.ForeColor = Color.Red;
					}
				}
				else
				{
					Res11.ForeColor = Color.FromArgb(167, 146, 221);
					Res12.ForeColor = Color.FromArgb(167, 146, 221);
				}

				if (champion1.stats.attackdamage > champion2.stats.attackdamage)
				{
					Res19.ForeColor = Color.Green;
					Res20.ForeColor = Color.Red;
				}
				else if (champion1.stats.attackdamage == champion2.stats.attackdamage)
				{
					Res19.ForeColor = Color.Blue;
					Res20.ForeColor = Color.Blue;
				}
				else
				{
					Res20.ForeColor = Color.Green;
					Res19.ForeColor = Color.Red;
				}
				
				if (champion1.stats.attackrange > champion2.stats.attackrange)
				{
					Res23.ForeColor = Color.Green;
					Res24.ForeColor = Color.Red;
				}
				else if (champion1.stats.attackrange == champion2.stats.attackrange)
				{
					Res23.ForeColor = Color.Blue;
					Res24.ForeColor = Color.Blue;
				}
				else
				{
					Res24.ForeColor = Color.Green;
					Res23.ForeColor = Color.Red;
				}
				
				if (champion1.stats.attackspeed > champion2.stats.attackspeed)
				{
					Res25.ForeColor = Color.Green;
					Res26.ForeColor = Color.Red;
				}
				else if (champion1.stats.attackspeed == champion2.stats.attackspeed)
				{
					Res25.ForeColor = Color.Blue;
					Res26.ForeColor = Color.Blue;
				}
				else
				{
					Res26.ForeColor = Color.Green;
					Res25.ForeColor = Color.Red;
				}
				
				if (champion1.stats.armor > champion2.stats.armor)
				{
					Res29.ForeColor = Color.Green;
					Res30.ForeColor = Color.Red;
				}
				else if (champion1.stats.armor == champion2.stats.armor)
				{
					Res29.ForeColor = Color.Blue;
					Res30.ForeColor = Color.Blue;
				}
				else
				{
					Res30.ForeColor = Color.Green;
					Res29.ForeColor = Color.Red;
				}
				
				if (champion1.stats.spellblock > champion2.stats.spellblock)
				{
					Res33.ForeColor = Color.Green;
					Res34.ForeColor = Color.Red;
				}
				else if (champion1.stats.spellblock == champion2.stats.spellblock)
				{
					Res33.ForeColor = Color.Blue;
					Res34.ForeColor = Color.Blue;
				}
				else
				{
					Res34.ForeColor = Color.Green;
					Res33.ForeColor = Color.Red;
				}
				
				if (champion1.stats.movespeed > champion2.stats.movespeed)
				{
					Res37.ForeColor = Color.Green;
					Res38.ForeColor = Color.Red;
				}
				else if (champion1.stats.movespeed == champion2.stats.movespeed)
				{
					Res37.ForeColor = Color.Blue;
					Res38.ForeColor = Color.Blue;
				}
				else
				{
					Res38.ForeColor = Color.Green;
					Res37.ForeColor = Color.Red;
				}
			}
			FirstChampTxt.Text = "";
			SecondChampTxt.Text = "";
		}
		private void DarkThemeBtn_Click(object sender, EventArgs e)
		{
			// Dark theme, a.k.a. the only good theme
			if (DarkThemeBtn.Text.Equals("Dark theme"))
			{
				this.BackColor = Color.FromArgb(19, 20, 20);
				PatchLbl.ForeColor = Color.White;
				
				FirstChampLbl.ForeColor = Color.White;
				SecondChampLbl.ForeColor = Color.White;
				
				FirstChampResultsLbl.ForeColor = Color.White;
				SecondChampResultsLbl.ForeColor = Color.White;
				
				HPStatsLbl.ForeColor = Color.DeepPink;
				HPLbl.ForeColor = Color.White;
				HPPerLvLbl.ForeColor = Color.White;
				Res3.ForeColor = Color.White;
				Res4.ForeColor = Color.White;
				HPRegenLbl.ForeColor = Color.White;
				Res5.ForeColor = Color.White;
				Res6.ForeColor = Color.White;
				HPRegenPerLvLbl.ForeColor = Color.White; 
				Res7.ForeColor = Color.White;
				Res8.ForeColor = Color.White;
				
				
				ManaStatsLbl.ForeColor = Color.DeepPink;
				TypeLbl.ForeColor = Color.White;
				Res9.ForeColor = Color.FromArgb(167, 146, 221);
				Res10.ForeColor = Color.FromArgb(167,146,221);
				ManaLbl.ForeColor = Color.White;
				ManaPerLvLbl.ForeColor = Color.White;
				Res13.ForeColor = Color.White;
				Res14.ForeColor = Color.White;
				ManaRegenLbl.ForeColor = Color.White;
				Res15.ForeColor = Color.White;
				Res16.ForeColor = Color.White;
				ManaRegenPerLvLbl.ForeColor = Color.White;
				Res17.ForeColor = Color.White;
				Res18.ForeColor = Color.White;
				
				AtkStatsLbl.ForeColor = Color.DeepPink;
				AtkDmgLbl.ForeColor = Color.White;
				AtkDmgPerLvLbl.ForeColor = Color.White;
				Res21.ForeColor = Color.White;
				Res22.ForeColor = Color.White;
				AtkRangeLbl.ForeColor = Color.White;
				AtkSpdLbl.ForeColor = Color.White;
				AtkSpdPerLvLbl.ForeColor = Color.White;
				Res27.ForeColor = Color.White;
				Res28.ForeColor = Color.White;
				
				ArmorStatsLbl.ForeColor = Color.DeepPink;
				ArmorLbl.ForeColor = Color.White;
				ArmorPerLvLbl.ForeColor = Color.White;
				Res31.ForeColor = Color.White;
				Res32.ForeColor = Color.White;
				
				MagicStatsLbl.ForeColor = Color.DeepPink;
				MagicResistanceLbl.ForeColor = Color.White;
				MagicResistancePerLvLbl.ForeColor = Color.White;
				Res35.ForeColor = Color.White;
				Res36.ForeColor = Color.White;
				
				MovementSpdLbl.ForeColor = Color.White;

				CoolStatsLbl.ForeColor = Color.DeepPink;
				QCoolLbl.ForeColor = Color.White;
				Res39.ForeColor = Color.White;
				Res40.ForeColor = Color.White;
				WCoolLbl.ForeColor = Color.White;
				Res41.ForeColor = Color.White;
				Res42.ForeColor = Color.White;
				ECoolLbl.ForeColor = Color.White;
				Res43.ForeColor = Color.White;
				Res44.ForeColor = Color.White;
				RCoolLbl.ForeColor = Color.White;
				Res45.ForeColor = Color.White;
				Res46.ForeColor = Color.White;
				
				DarkThemeBtn.Text = "Light theme";
			}
			else
			{
				this.BackColor = Color.White;
				PatchLbl.ForeColor = Color.Black;
				
				FirstChampLbl.ForeColor = Color.Black;
				SecondChampLbl.ForeColor = Color.Black;
				
				FirstChampResultsLbl.ForeColor = Color.Black;
				SecondChampResultsLbl.ForeColor = Color.Black;
				
				HPStatsLbl.ForeColor = Color.DeepPink;
				HPLbl.ForeColor = Color.Black;
				HPPerLvLbl.ForeColor = Color.Black;
				Res3.ForeColor = Color.Black;
				Res4.ForeColor = Color.Black;
				HPRegenLbl.ForeColor = Color.Black;
				Res5.ForeColor = Color.Black;
				Res6.ForeColor = Color.Black;
				HPRegenPerLvLbl.ForeColor = Color.Black; 
				Res7.ForeColor = Color.Black;
				Res8.ForeColor = Color.Black;
				
				
				ManaStatsLbl.ForeColor = Color.DeepPink;
				TypeLbl.ForeColor = Color.Black;
				Res9.ForeColor = Color.FromArgb(167, 146, 221);
				Res10.ForeColor = Color.FromArgb(167,146,221);
				ManaLbl.ForeColor = Color.Black;
				ManaPerLvLbl.ForeColor = Color.Black;
				Res13.ForeColor = Color.Black;
				Res14.ForeColor = Color.Black;
				ManaRegenLbl.ForeColor = Color.Black;
				Res15.ForeColor = Color.Black;
				Res16.ForeColor = Color.Black;
				ManaRegenPerLvLbl.ForeColor = Color.Black;
				Res17.ForeColor = Color.Black;
				Res18.ForeColor = Color.Black;
				
				AtkStatsLbl.ForeColor = Color.DeepPink;
				AtkDmgLbl.ForeColor = Color.Black;
				AtkDmgPerLvLbl.ForeColor = Color.Black;
				Res21.ForeColor = Color.Black;
				Res22.ForeColor = Color.Black;
				AtkRangeLbl.ForeColor = Color.Black;
				AtkSpdLbl.ForeColor = Color.Black;
				AtkSpdPerLvLbl.ForeColor = Color.Black;
				Res27.ForeColor = Color.Black;
				Res28.ForeColor = Color.Black;
				
				ArmorStatsLbl.ForeColor = Color.DeepPink;
				ArmorLbl.ForeColor = Color.Black;
				ArmorPerLvLbl.ForeColor = Color.Black;
				Res31.ForeColor = Color.Black;
				Res32.ForeColor = Color.Black;
				
				MagicStatsLbl.ForeColor = Color.DeepPink;
				MagicResistanceLbl.ForeColor = Color.Black;
				MagicResistancePerLvLbl.ForeColor = Color.Black;
				Res35.ForeColor = Color.Black;
				Res36.ForeColor = Color.Black;
				
				MovementSpdLbl.ForeColor = Color.Black;

				CoolStatsLbl.ForeColor = Color.DeepPink;
				QCoolLbl.ForeColor = Color.Black;
				Res39.ForeColor = Color.Black;
				Res40.ForeColor = Color.Black;
				WCoolLbl.ForeColor = Color.Black;
				Res41.ForeColor = Color.Black;
				Res42.ForeColor = Color.Black;
				ECoolLbl.ForeColor = Color.Black;
				Res43.ForeColor = Color.Black;
				Res44.ForeColor = Color.Black;
				RCoolLbl.ForeColor = Color.Black;
				Res45.ForeColor = Color.Black;
				Res46.ForeColor = Color.Black;
				DarkThemeBtn.Text = "Dark theme";
			}
		}
		// Ledda did this. Don't know what does.
		// It opens that link when you click on "movement speed" 10 times
		private void MovementSpdLbl_Click(object sender, EventArgs e)
		{
			_z++;
			if (_z == 10)
			{
				Process.Start(new ProcessStartInfo("https://raw.githubusercontent.com/LeddaZ/LeddaZ.github.io/master/assets/heh.gif") {UseShellExecute = true});
			}
		}

        private void Main_Load(object sender, EventArgs e)
        {
			// Set custom font "Karla" from Google Fonts
			foreach (Control c in Controls)
            {
				//if (c.Name.Equals("FirstChampLbl"))
				Extra.UseCustomFont("Karla", 13, c);
			}

			// Set the latest patch number on the corresponding label
			PatchLbl.Text += Extra.GetPatch();
		}
    }
}
