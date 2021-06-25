using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ChampionComparatorGUI
{
    public partial class Main : Form
    {
        string[] stats = new string[46];
        int _z;

        public Main()
        {
            InitializeComponent();

            HPRegenLbl.Location = new Point(HPRegenLbl.Location.X, HPRegenLbl.Location.Y - 26);
            Res5.Location = new Point(Res5.Location.X, Res5.Location.Y - 26);
            Res6.Location = new Point(Res6.Location.X, Res6.Location.Y - 26);

            ManaStatsLbl.Location = new Point(ManaStatsLbl.Location.X, ManaStatsLbl.Location.Y - 46);
            TypeLbl.Location = new Point(TypeLbl.Location.X, TypeLbl.Location.Y - 46);
            Res9.Location = new Point(Res9.Location.X, Res9.Location.Y - 46);
            Res10.Location = new Point(Res10.Location.X, Res10.Location.Y - 46);
            ManaLbl.Location = new Point(ManaLbl.Location.X, ManaLbl.Location.Y - 46);
            Res11.Location = new Point(Res11.Location.X, Res11.Location.Y - 46);
            Res12.Location = new Point(Res12.Location.X, Res12.Location.Y - 46);
            ManaRegenLbl.Location = new Point(ManaRegenLbl.Location.X, ManaRegenLbl.Location.Y - 70);
            Res15.Location = new Point(Res15.Location.X, Res15.Location.Y - 70);
            Res16.Location = new Point(Res16.Location.X, Res16.Location.Y - 70);

            AtkStatsLbl.Location = new Point(AtkStatsLbl.Location.X, AtkStatsLbl.Location.Y - 90);
            AtkDmgLbl.Location = new Point(AtkDmgLbl.Location.X, AtkDmgLbl.Location.Y - 90);
            Res19.Location = new Point(Res19.Location.X, Res19.Location.Y - 90);
            Res20.Location = new Point(Res20.Location.X, Res20.Location.Y - 90);
            AtkRangeLbl.Location = new Point(AtkRangeLbl.Location.X, AtkRangeLbl.Location.Y - 110);
            Res23.Location = new Point(Res23.Location.X, Res23.Location.Y - 110);
            Res24.Location = new Point(Res24.Location.X, Res24.Location.Y - 110);
            AtkSpdLbl.Location = new Point(AtkSpdLbl.Location.X, AtkSpdLbl.Location.Y - 110);
            Res25.Location = new Point(Res25.Location.X, Res25.Location.Y - 110);
            Res26.Location = new Point(Res26.Location.X, Res26.Location.Y - 110);

            ArmorStatsLbl.Location = new Point(ArmorStatsLbl.Location.X, ArmorStatsLbl.Location.Y - 130);
            ArmorLbl.Location = new Point(ArmorLbl.Location.X, ArmorLbl.Location.Y - 130);
            Res29.Location = new Point(Res29.Location.X, Res29.Location.Y - 130);
            Res30.Location = new Point(Res30.Location.X, Res30.Location.Y - 130);

            MagicStatsLbl.Location = new Point(MagicStatsLbl.Location.X, MagicStatsLbl.Location.Y - 150);
            MagicResistanceLbl.Location = new Point(MagicResistanceLbl.Location.X, MagicResistanceLbl.Location.Y - 150);
            Res33.Location = new Point(Res33.Location.X, Res33.Location.Y - 150);
            Res34.Location = new Point(Res34.Location.X, Res34.Location.Y - 150);

            MovementSpdLbl.Location = new Point(MovementSpdLbl.Location.X, MovementSpdLbl.Location.Y - 170);
            Res37.Location = new Point(Res37.Location.X, Res37.Location.Y - 170);
            Res38.Location = new Point(Res38.Location.X, Res38.Location.Y - 170);

            CoolStatsLbl.Location = new Point(CoolStatsLbl.Location.X, CoolStatsLbl.Location.Y - 175);
            QCoolLbl.Location = new Point(QCoolLbl.Location.X, QCoolLbl.Location.Y - 175);
            Res39.Location = new Point(Res39.Location.X, Res39.Location.Y - 175);
            Res40.Location = new Point(Res40.Location.X, Res40.Location.Y - 175);
            WCoolLbl.Location = new Point(WCoolLbl.Location.X, WCoolLbl.Location.Y - 175);
            Res41.Location = new Point(Res41.Location.X, Res41.Location.Y - 175);
            Res42.Location = new Point(Res42.Location.X, Res42.Location.Y - 175);
            ECoolLbl.Location = new Point(ECoolLbl.Location.X, ECoolLbl.Location.Y - 175);
            Res43.Location = new Point(Res43.Location.X, Res43.Location.Y - 175);
            Res44.Location = new Point(Res44.Location.X, Res44.Location.Y - 175);
            RCoolLbl.Location = new Point(RCoolLbl.Location.X, RCoolLbl.Location.Y - 175);
            Res45.Location = new Point(Res45.Location.X, Res45.Location.Y - 175);
            Res46.Location = new Point(Res46.Location.X, Res46.Location.Y - 175);




        }

        public void BtnConfirm_Click(object sender, EventArgs e)
        {
            // Show champ names above the results when "Confirm" is clicked
            string ch1 = FirstChampTxt.Text;
            string ch2 = SecondChampTxt.Text;

            /* Store lowercase names in separate variables so I can show the
			* original names in the form */
            string champ1 = ch1.ToLower().Contains("mundo") ? "DrMundo" : (ch1.ToLower().Contains("sol") ? "AurelionSol" : (ch1.ToLower().Contains("jarvan") ? "JarvanIV" : ((!ch1.ToLower().Equals("kai'sa") && !ch1.ToLower().Equals("kai sa")) ? (ch1.ToLower().Contains("kha") ? "Khazix" : (ch1.ToLower().Contains("kog") ? "KogMaw" : ((!ch1.ToLower().Equals("leesin") && !ch1.ToLower().Equals("lee sin")) ? (ch1.ToLower().Contains("master") ? "MasterYi" : (ch1.ToLower().Contains("miss") ? "MissFortune" : (ch1.ToLower().Contains("wukong") ? "MonkeyKing" : ((!ch1.ToLower().Equals("rek'sai") && !ch1.ToLower().Equals("reksai") && !ch1.ToLower().Equals("rek sai")) ? (ch1.ToLower().Contains("tahm") ? "TahmKench" : (ch1.ToLower().Contains("twisted") ? "TwistedFate" : ((ch1.ToLower().Equals("vel'koz") || ch1.ToLower().Equals("vel koz")) ? "Velkoz" : (ch1.ToLower().Contains("xin") ? "XinZhao" : (ch1.ToLower().Contains("pasquetto") ? "Shaco" : ((!ch1.Contains(" ")) ? (char.ToUpper(ch1[0]) + ch1.Substring(1).ToLower()) : (char.ToUpper(ch1[0]) + ch1.Substring(1).ToLower().TrimEnd(' ')))))))) : "RekSai")))) : "LeeSin"))) : "Kaisa")));
            string champ2 = ch2.ToLower().Contains("mundo") ? "DrMundo" : (ch2.ToLower().Contains("sol") ? "AurelionSol" : (ch2.ToLower().Contains("jarvan") ? "JarvanIV" : ((!ch2.ToLower().Equals("kai'sa") && !ch2.ToLower().Equals("kai sa")) ? (ch2.ToLower().Contains("kha") ? "Khazix" : (ch2.ToLower().Contains("kog") ? "KogMaw" : ((!ch2.ToLower().Equals("leesin") && !ch2.ToLower().Equals("lee sin")) ? (ch2.ToLower().Contains("master") ? "MasterYi" : (ch2.ToLower().Contains("miss") ? "MissFortune" : (ch2.ToLower().Contains("wukong") ? "MonkeyKing" : ((!ch2.ToLower().Equals("rek'sai") && !ch2.ToLower().Equals("reksai") && !ch2.ToLower().Equals("rek sai")) ? (ch2.ToLower().Contains("tahm") ? "TahmKench" : (ch2.ToLower().Contains("twisted") ? "TwistedFate" : ((ch2.ToLower().Equals("vel'koz") || ch2.ToLower().Equals("vel koz")) ? "Velkoz" : (ch2.ToLower().Contains("xin") ? "XinZhao" : (ch2.ToLower().Contains("pasquetto") ? "Shaco" : ((!ch2.Contains(" ")) ? (char.ToUpper(ch2[0]) + ch2.Substring(1).ToLower()) : (char.ToUpper(ch2[0]) + ch2.Substring(1).ToLower().TrimEnd(' ')))))))) : "RekSai")))) : "LeeSin"))) : "Kaisa")));

            // Try to get champ1 image from files. Otherwise get it from the API
            string pathChampion1 = $@".\Assets\Champions\{champ1}.png";
            if (File.Exists(pathChampion1))
            {
                FirstChampPic.ImageLocation = pathChampion1;
            }
            else
            {
                FirstChampPic.ImageLocation = $@"http://ddragon.leagueoflegends.com/cdn/{Extra.GetPatch()}/img/champion/{champ1}.png";
            }
            FirstChampPic.SizeMode = PictureBoxSizeMode.StretchImage;
            FirstChampPic.Visible = true;

            // Try to get champ2 image from files. Otherwise get it from the API
            string pathChampion2 = $@".\Assets\Champions\{champ2}.png";
            if (File.Exists(pathChampion2))
            {
                SecondChampPic.ImageLocation = pathChampion2;
            }
            else
            {
                SecondChampPic.ImageLocation = $@"http://ddragon.leagueoflegends.com/cdn/{Extra.GetPatch()}/img/champion/{champ2}.png";
            }
            SecondChampPic.SizeMode = PictureBoxSizeMode.StretchImage;
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
                stats[0] = champion1.stats.hp.ToString(CultureInfo.InvariantCulture);
                stats[1] = champion2.stats.hp.ToString(CultureInfo.InvariantCulture);
                stats[2] = $"+{champion1.stats.hpperlevel}";
                stats[3] = $"+{champion2.stats.hpperlevel}";
                stats[4] = Math.Round(champion1.stats.hpregen / 5, 1, MidpointRounding.ToEven).ToString(CultureInfo.InvariantCulture);
                stats[5] = Math.Round(champion2.stats.hpregen / 5, 1, MidpointRounding.ToEven).ToString(CultureInfo.InvariantCulture);
                stats[6] = $"+{champion1.stats.hpregenperlevel}";
                stats[7] = $"+{champion2.stats.hpregenperlevel}";
                stats[8] = champion1.partype;
                stats[9] = champion2.partype;
                stats[10] = champion1.stats.mp.ToString(CultureInfo.InvariantCulture);
                stats[11] = champion2.stats.mp.ToString(CultureInfo.InvariantCulture);
                stats[12] = $"+{champion1.stats.mpperlevel}";
                stats[13] = $"+{champion2.stats.mpperlevel}";
                stats[14] = Math.Round(champion1.stats.mpregen / 5, 1, MidpointRounding.ToEven).ToString(CultureInfo.InvariantCulture);
                stats[15] = Math.Round(champion2.stats.mpregen / 5, 1, MidpointRounding.ToEven).ToString(CultureInfo.InvariantCulture);
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
                foreach (Control c in Controls)
                {
                    if (c.Name.StartsWith("Res"))
                    {
                        labels[i] = (Label)c;
                        labels[i].Visible = true;
                        labels[i].Text = stats[i];
                        i++;
                    }
                }
                if (AdvancedStatsBtn.Text.Equals("Show Advanced Stats"))
                {
                    Res3.Visible = false;
                    Res4.Visible = false;
                    Res7.Visible = false;
                    Res8.Visible = false;
                    Res13.Visible = false;
                    Res14.Visible = false;
                    Res17.Visible = false;
                    Res18.Visible = false;
                    Res21.Visible = false;
                    Res22.Visible = false;
                    Res27.Visible = false;
                    Res28.Visible = false;
                    Res31.Visible = false;
                    Res32.Visible = false;
                    Res35.Visible = false;
                    Res36.Visible = false;
                }
                else
                {
                    Res3.Visible = true;
                    Res4.Visible = true;
                    Res7.Visible = true;
                    Res8.Visible = true;
                    Res13.Visible = true;
                    Res14.Visible = true;
                    Res17.Visible = true;
                    Res18.Visible = true;
                    Res21.Visible = true;
                    Res22.Visible = true;
                    Res27.Visible = true;
                    Res28.Visible = true;
                    Res31.Visible = true;
                    Res32.Visible = true;
                    Res35.Visible = true;
                    Res36.Visible = true;
                }

                // Set the colors of the most important stats. Netu died inside to do this.
                if (champion1.stats.hp > champion2.stats.hp)
                {
                    Res1.ForeColor = Color.Green;
                    Res2.ForeColor = Color.Red;
                }
                else if (champion1.stats.hp == champion2.stats.hp)
                {
                    Res1.ForeColor = Color.FromArgb(15, 82, 186);
                    Res2.ForeColor = Color.FromArgb(15, 82, 186);
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
                        Res11.ForeColor = Color.FromArgb(15, 82, 186);
                        Res12.ForeColor = Color.FromArgb(15, 82, 186);
                    }
                    else
                    {
                        Res12.ForeColor = Color.Green;
                        Res11.ForeColor = Color.Red;
                    }
                }
                else
                {
                    Res11.ForeColor = Color.FromArgb(119, 123, 126);
                    Res12.ForeColor = Color.FromArgb(119, 123, 126);
                }

                if (champion1.stats.attackdamage > champion2.stats.attackdamage)
                {
                    Res19.ForeColor = Color.Green;
                    Res20.ForeColor = Color.Red;
                }
                else if (champion1.stats.attackdamage == champion2.stats.attackdamage)
                {
                    Res19.ForeColor = Color.FromArgb(15, 82, 186);
                    Res20.ForeColor = Color.FromArgb(15, 82, 186);
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
                    Res23.ForeColor = Color.FromArgb(15, 82, 186);
                    Res24.ForeColor = Color.FromArgb(15, 82, 186);
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
                    Res25.ForeColor = Color.FromArgb(15, 82, 186);
                    Res26.ForeColor = Color.FromArgb(15, 82, 186);
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
                    Res29.ForeColor = Color.FromArgb(15, 82, 186);
                    Res30.ForeColor = Color.FromArgb(15, 82, 186);
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
                    Res33.ForeColor = Color.FromArgb(15, 82, 186);
                    Res34.ForeColor = Color.FromArgb(15, 82, 186);
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
                    Res37.ForeColor = Color.FromArgb(15, 82, 186);
                    Res38.ForeColor = Color.FromArgb(15, 82, 186);
                }
                else
                {
                    Res38.ForeColor = Color.Green;
                    Res37.ForeColor = Color.Red;
                }
            }
            //When load the champions the TextBox are cleaned
            FirstChampTxt.Text = "";
            SecondChampTxt.Text = "";
            LevelTrackBar.Value = 1;
            LevelLbl.Visible = true;
            LevelLbl.Text = $"Lvl: {LevelTrackBar.Value.ToString()}";
        }
        private void DarkThemeBtn_Click(object sender, EventArgs e)
        {
            // Dark theme, a.k.a. the only good theme
            if (DarkThemeBtn.Text.Equals("Dark theme"))
            {
                BackColor = Color.FromArgb(38, 38, 38);
                PatchLbl.ForeColor = Color.White;
                LevelLbl.ForeColor = Color.White;

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
                Res10.ForeColor = Color.FromArgb(167, 146, 221);
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

                DarkThemeBtn.Text = @"Light theme";
            }
            else
            {
                BackColor = Color.White;
                PatchLbl.ForeColor = Color.Black;
                LevelLbl.ForeColor = Color.Black;

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
                Res10.ForeColor = Color.FromArgb(167, 146, 221);
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
                DarkThemeBtn.Text = @"Dark theme";
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Set the latest patch number on the corresponding label
            PatchLbl.Text += Extra.GetPatch();
        }

        private void MovementSpdLbl_Click(object sender, EventArgs e)
        {
            // Ledda did this. Don't know what does.
            // It opens that link when you click on "movement speed" 10 times
            _z++;
            if (_z == 10)
            {
                Process.Start(new ProcessStartInfo("https://raw.githubusercontent.com/LeddaZ/LeddaZ.github.io/master/assets/heh.gif") { UseShellExecute = true });

            }
        }
        private void FirstChampPic_Click(object sender, EventArgs e)
        {
            //It opens that link if the first champion is Shaco and you click his image
            string pasqiShacoLocal = @".\Assets\Champions\Shaco.png";
            string pasqiShacoOnline = $@"http://ddragon.leagueoflegends.com/cdn/{Extra.GetPatch()}/img/champion/Shaco.png";
            if (FirstChampPic.ImageLocation == pasqiShacoLocal)
            {
                Process.Start(new ProcessStartInfo("https://i.imgur.com/yigxqCR.jpeg") { UseShellExecute = true });
            }
            else if (FirstChampPic.ImageLocation == pasqiShacoOnline)
            {
                Process.Start(new ProcessStartInfo("https://i.imgur.com/yigxqCR.jpeg") { UseShellExecute = true });
            }
        }

        private void LevelTrackBar_Scroll(object sender, EventArgs e)
        {
            //Change HP Stats when slider is used (CultureInfo.InvariantCulture is not used cause create problem with some champions)
            Res1.Text = Math.Round(double.Parse(stats[0], CultureInfo.InvariantCulture) + double.Parse(stats[2]) * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 2, MidpointRounding.ToEven).ToString();
            Res2.Text = Math.Round(double.Parse(stats[1], CultureInfo.InvariantCulture) + double.Parse(stats[3]) * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 2, MidpointRounding.ToEven).ToString();
            if (Convert.ToDouble(Res1.Text) > Convert.ToDouble(Res2.Text))
            {
                Res1.ForeColor = Color.Green;
                Res2.ForeColor = Color.Red;
            }
            else if (Convert.ToDouble(Res1.Text) == Convert.ToDouble(Res2.Text))
            {
                Res1.ForeColor = Color.FromArgb(15, 82, 186);
                Res2.ForeColor = Color.FromArgb(15, 82, 186);
            }
            else
            {
                Res2.ForeColor = Color.Green;
                Res1.ForeColor = Color.Red;
            }

            //Change HP Regen Stats when slider is used (CultureInfo.InvariantCulture is not used cause create problem with some champions)
            Res5.Text = Math.Round(double.Parse(stats[4], CultureInfo.InvariantCulture) + double.Parse(stats[6]) / 5 * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 1, MidpointRounding.ToEven).ToString();
            Res6.Text = Math.Round(double.Parse(stats[5], CultureInfo.InvariantCulture) + double.Parse(stats[7]) / 5 * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 1, MidpointRounding.ToEven).ToString();

            //Change Mana Stats when slider is used (CultureInfo.InvariantCulture is not used cause create problem with some champions)
            Res11.Text = Math.Round(double.Parse(stats[10], CultureInfo.InvariantCulture) + double.Parse(stats[12]) * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 2, MidpointRounding.ToEven).ToString();
            Res12.Text = Math.Round(double.Parse(stats[11], CultureInfo.InvariantCulture) + double.Parse(stats[13]) * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 2, MidpointRounding.ToEven).ToString();
            if (Res9.Text == Res10.Text)
            {
                if (Convert.ToDouble(Res11.Text) > Convert.ToDouble(Res12.Text))
                {
                    Res11.ForeColor = Color.Green;
                    Res12.ForeColor = Color.Red;
                }
                else if (Convert.ToDouble(Res11.Text) == Convert.ToDouble(Res12.Text))
                {
                    Res11.ForeColor = Color.FromArgb(15, 82, 186);
                    Res12.ForeColor = Color.FromArgb(15, 82, 186);
                }
                else
                {
                    Res12.ForeColor = Color.Green;
                    Res11.ForeColor = Color.Red;
                }
            }

            //Change Mana Regen Stats when slider is used (CultureInfo.InvariantCulture is not used cause create problem with some champions)
            Res15.Text = Math.Round(double.Parse(stats[14], CultureInfo.InvariantCulture) + double.Parse(stats[16]) / 5 * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 1, MidpointRounding.ToEven).ToString();
            Res16.Text = Math.Round(double.Parse(stats[15], CultureInfo.InvariantCulture) + double.Parse(stats[17]) / 5 * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 1, MidpointRounding.ToEven).ToString();

            //Change Attack Stats when slider is used (CultureInfo.InvariantCulture is not used cause create problem with some champions)
            Res19.Text = Math.Round(double.Parse(stats[18], CultureInfo.InvariantCulture) + double.Parse(stats[20]) * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 2, MidpointRounding.ToEven).ToString();
            Res20.Text = Math.Round(double.Parse(stats[19], CultureInfo.InvariantCulture) + double.Parse(stats[21]) * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 2, MidpointRounding.ToEven).ToString();
            if (Convert.ToDouble(Res19.Text) > Convert.ToDouble(Res20.Text))
            {
                Res19.ForeColor = Color.Green;
                Res20.ForeColor = Color.Red;
            }
            else if (Convert.ToDouble(Res19.Text) == Convert.ToDouble(Res20.Text))
            {
                Res19.ForeColor = Color.FromArgb(15, 82, 186);
                Res20.ForeColor = Color.FromArgb(15, 82, 186);
            }
            else
            {
                Res20.ForeColor = Color.Green;
                Res19.ForeColor = Color.Red;
            }

            //Calculation of the ATK Speed Bonus per level selected
            var atkSpeedBonusChamp1 = Math.Round(0 + Convert.ToDouble(stats[26].TrimEnd('%')) * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 3, MidpointRounding.ToEven).ToString();
            var atkSpeedBonusChamp2 = Math.Round(0 + Convert.ToDouble(stats[27].TrimEnd('%')) * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 3, MidpointRounding.ToEven).ToString();
            //Change Attack Speed stats when slider is used (CultureInfo.InvariantCulture is not used cause create problem with some champions)
            Res25.Text = Math.Round(double.Parse(stats[24], CultureInfo.InvariantCulture) * (1 + double.Parse(atkSpeedBonusChamp1) / 100), 3, MidpointRounding.ToEven).ToString();
            Res26.Text = Math.Round(double.Parse(stats[25], CultureInfo.InvariantCulture) * (1 + double.Parse(atkSpeedBonusChamp2) / 100), 3, MidpointRounding.ToEven).ToString();
            if (Convert.ToDouble(Res25.Text) > Convert.ToDouble(Res26.Text))
            {
                Res25.ForeColor = Color.Green;
                Res26.ForeColor = Color.Red;
            }
            else if (Convert.ToDouble(Res25.Text) == Convert.ToDouble(Res26.Text))
            {
                Res25.ForeColor = Color.FromArgb(15, 82, 186);
                Res26.ForeColor = Color.FromArgb(15, 82, 186);
            }
            else
            {
                Res26.ForeColor = Color.Green;
                Res25.ForeColor = Color.Red;
            }

            //Change Armor Stats when slider is used (CultureInfo.InvariantCulture is not used cause create problem with some champions)
            Res29.Text = Math.Round(double.Parse(stats[28], CultureInfo.InvariantCulture) + double.Parse(stats[30]) * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 2, MidpointRounding.ToEven).ToString();
            Res30.Text = Math.Round(double.Parse(stats[29], CultureInfo.InvariantCulture) + double.Parse(stats[31]) * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 2, MidpointRounding.ToEven).ToString();
            if (Convert.ToDouble(Res29.Text) > Convert.ToDouble(Res30.Text))
            {
                Res29.ForeColor = Color.Green;
                Res30.ForeColor = Color.Red;
            }
            else if (Convert.ToDouble(Res29.Text) == Convert.ToDouble(Res30.Text))
            {
                Res29.ForeColor = Color.FromArgb(15, 82, 186);
                Res30.ForeColor = Color.FromArgb(15, 82, 186);
            }
            else
            {
                Res30.ForeColor = Color.Green;
                Res29.ForeColor = Color.Red;
            }

            //Change Magic Resistence Stats when slider is used (CultureInfo.InvariantCulture is not used cause create problem with some champions)
            Res33.Text = Math.Round(double.Parse(stats[32], CultureInfo.InvariantCulture) + double.Parse(stats[34]) * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 2, MidpointRounding.ToEven).ToString();
            Res34.Text = Math.Round(double.Parse(stats[33], CultureInfo.InvariantCulture) + double.Parse(stats[35]) * (LevelTrackBar.Value - 1) * (0.7025 + 0.0175 * (LevelTrackBar.Value - 1)), 2, MidpointRounding.ToEven).ToString();

            if (Convert.ToDouble(Res33.Text) > Convert.ToDouble(Res34.Text))
            {
                Res33.ForeColor = Color.Green;
                Res34.ForeColor = Color.Red;
            }
            else if (Convert.ToDouble(Res33.Text) == Convert.ToDouble(Res34.Text))
            {
                Res33.ForeColor = Color.FromArgb(15, 82, 186);
                Res34.ForeColor = Color.FromArgb(15, 82, 186);
            }
            else
            {
                Res34.ForeColor = Color.Green;
                Res33.ForeColor = Color.Red;
            }
            //Show the value of the level slider position
            LevelLbl.Text = $"Lvl: {LevelTrackBar.Value.ToString()}";
        }

        private void AdvancedStatsBtn_Click(object sender, EventArgs e)
        {
            if (AdvancedStatsBtn.Text.Equals("Show Advanced Stats"))
            {
                HPPerLvLbl.Visible = true;
                if (Res3.Text.Equals("hp1") && Res4.Text.Equals("hp1"))
                {
                    Res3.Visible = false;
                    Res4.Visible = false;
                }
                else
                {
                    Res3.Visible = true;
                    Res4.Visible = true;
                }
                HPRegenLbl.Location = new Point(HPRegenLbl.Location.X, HPRegenLbl.Location.Y + 26);
                Res5.Location = new Point(Res5.Location.X, Res5.Location.Y + 26);
                Res6.Location = new Point(Res6.Location.X, Res6.Location.Y + 26);
                HPRegenPerLvLbl.Visible = true;
                if (Res7.Text.Equals("hp1") && Res8.Text.Equals("hp1"))
                {
                    Res7.Visible = false;
                    Res8.Visible = false;
                }
                else
                {
                    Res7.Visible = true;
                    Res8.Visible = true;
                }

                ManaStatsLbl.Location = new Point(ManaStatsLbl.Location.X, ManaStatsLbl.Location.Y + 46);
                TypeLbl.Location = new Point(TypeLbl.Location.X, TypeLbl.Location.Y + 46);
                Res9.Location = new Point(Res9.Location.X, Res9.Location.Y + 46);
                Res10.Location = new Point(Res10.Location.X, Res10.Location.Y + 46);
                ManaLbl.Location = new Point(ManaLbl.Location.X, ManaLbl.Location.Y + 46);
                Res11.Location = new Point(Res11.Location.X, Res11.Location.Y + 46);
                Res12.Location = new Point(Res12.Location.X, Res12.Location.Y + 46);
                ManaPerLvLbl.Visible = true;
                if (Res13.Text.Equals("hp1") && Res14.Text.Equals("hp1"))
                {
                    Res13.Visible = false;
                    Res14.Visible = false;
                }
                else
                {
                    Res13.Visible = true;
                    Res14.Visible = true;
                }
                ManaRegenLbl.Location = new Point(ManaRegenLbl.Location.X, ManaRegenLbl.Location.Y + 70);
                Res15.Location = new Point(Res15.Location.X, Res15.Location.Y + 70);
                Res16.Location = new Point(Res16.Location.X, Res16.Location.Y + 70);
                ManaRegenPerLvLbl.Visible = true;
                if (Res17.Text.Equals("hp1") && Res18.Text.Equals("hp1"))
                {
                    Res17.Visible = false;
                    Res18.Visible = false;
                }
                else
                {
                    Res17.Visible = true;
                    Res18.Visible = true;
                }

                AtkStatsLbl.Location = new Point(AtkStatsLbl.Location.X, AtkStatsLbl.Location.Y + 90);
                AtkDmgLbl.Location = new Point(AtkDmgLbl.Location.X, AtkDmgLbl.Location.Y + 90);
                Res19.Location = new Point(Res19.Location.X, Res19.Location.Y + 90);
                Res20.Location = new Point(Res20.Location.X, Res20.Location.Y + 90);
                AtkDmgPerLvLbl.Visible = true;
                if (Res21.Text.Equals("hp1") && Res22.Text.Equals("hp1"))
                {
                    Res21.Visible = false;
                    Res22.Visible = false;
                }
                else
                {
                    Res21.Visible = true;
                    Res22.Visible = true;
                }
                AtkRangeLbl.Location = new Point(AtkRangeLbl.Location.X, AtkRangeLbl.Location.Y + 110);
                Res23.Location = new Point(Res23.Location.X, Res23.Location.Y + 110);
                Res24.Location = new Point(Res24.Location.X, Res24.Location.Y + 110);
                AtkSpdLbl.Location = new Point(AtkSpdLbl.Location.X, AtkSpdLbl.Location.Y + 110);
                Res25.Location = new Point(Res25.Location.X, Res25.Location.Y + 110);
                Res26.Location = new Point(Res26.Location.X, Res26.Location.Y + 110);
                AtkSpdPerLvLbl.Visible = true;
                if (Res27.Text.Equals("hp1") && Res28.Text.Equals("hp1"))
                {
                    Res27.Visible = false;
                    Res28.Visible = false;
                }
                else
                {
                    Res27.Visible = true;
                    Res28.Visible = true;
                }

                ArmorStatsLbl.Location = new Point(ArmorStatsLbl.Location.X, ArmorStatsLbl.Location.Y + 130);
                ArmorLbl.Location = new Point(ArmorLbl.Location.X, ArmorLbl.Location.Y + 130);
                Res29.Location = new Point(Res29.Location.X, Res29.Location.Y + 130);
                Res30.Location = new Point(Res30.Location.X, Res30.Location.Y + 130);
                ArmorPerLvLbl.Visible = true;
                if (Res31.Text.Equals("hp1") && Res32.Text.Equals("hp1"))
                {
                    Res31.Visible = false;
                    Res32.Visible = false;
                }
                else
                {
                    Res31.Visible = true;
                    Res32.Visible = true;
                }

                MagicStatsLbl.Location = new Point(MagicStatsLbl.Location.X, MagicStatsLbl.Location.Y + 150);
                MagicResistanceLbl.Location = new Point(MagicResistanceLbl.Location.X, MagicResistanceLbl.Location.Y + 150);
                Res33.Location = new Point(Res33.Location.X, Res33.Location.Y + 150);
                Res34.Location = new Point(Res34.Location.X, Res34.Location.Y + 150);
                MagicResistanceLbl.Visible = true;
                if (Res35.Text.Equals("hp1") && Res36.Text.Equals("hp1"))
                {
                    Res35.Visible = false;
                    Res36.Visible = false;
                }
                else
                {
                    Res35.Visible = true;
                    Res36.Visible = true;
                }

                MovementSpdLbl.Location = new Point(MovementSpdLbl.Location.X, MovementSpdLbl.Location.Y + 170);
                Res37.Location = new Point(Res37.Location.X, Res37.Location.Y + 170);
                Res38.Location = new Point(Res38.Location.X, Res38.Location.Y + 170);

                CoolStatsLbl.Location = new Point(CoolStatsLbl.Location.X, CoolStatsLbl.Location.Y + 175);
                QCoolLbl.Location = new Point(QCoolLbl.Location.X, QCoolLbl.Location.Y + 175);
                Res39.Location = new Point(Res39.Location.X, Res39.Location.Y + 175);
                Res40.Location = new Point(Res40.Location.X, Res40.Location.Y + 175);
                WCoolLbl.Location = new Point(WCoolLbl.Location.X, WCoolLbl.Location.Y + 175);
                Res41.Location = new Point(Res41.Location.X, Res41.Location.Y + 175);
                Res42.Location = new Point(Res42.Location.X, Res42.Location.Y + 175);
                ECoolLbl.Location = new Point(ECoolLbl.Location.X, ECoolLbl.Location.Y + 175);
                Res43.Location = new Point(Res43.Location.X, Res43.Location.Y + 175);
                Res44.Location = new Point(Res44.Location.X, Res44.Location.Y + 175);
                RCoolLbl.Location = new Point(RCoolLbl.Location.X, RCoolLbl.Location.Y + 175);
                Res45.Location = new Point(Res45.Location.X, Res45.Location.Y + 175);
                Res46.Location = new Point(Res46.Location.X, Res46.Location.Y + 175);

                AdvancedStatsBtn.Text = @"Hide Advanced Stats";
            }
            else
            {
                HPPerLvLbl.Visible = false;
                Res3.Visible = false;
                Res4.Visible = false;
                HPRegenLbl.Location = new Point(HPRegenLbl.Location.X, HPRegenLbl.Location.Y - 26);
                Res5.Location = new Point(Res5.Location.X, Res5.Location.Y - 26);
                Res6.Location = new Point(Res6.Location.X, Res6.Location.Y - 26);
                HPRegenPerLvLbl.Visible = false;
                Res7.Visible = false;
                Res8.Visible = false;

                ManaStatsLbl.Location = new Point(ManaStatsLbl.Location.X, ManaStatsLbl.Location.Y - 46);
                TypeLbl.Location = new Point(TypeLbl.Location.X, TypeLbl.Location.Y - 46);
                Res9.Location = new Point(Res9.Location.X, Res9.Location.Y - 46);
                Res10.Location = new Point(Res10.Location.X, Res10.Location.Y - 46);
                ManaLbl.Location = new Point(ManaLbl.Location.X, ManaLbl.Location.Y - 46);
                Res11.Location = new Point(Res11.Location.X, Res11.Location.Y - 46);
                Res12.Location = new Point(Res12.Location.X, Res12.Location.Y - 46);
                ManaPerLvLbl.Visible = false;
                Res13.Visible = false;
                Res14.Visible = false;
                ManaRegenLbl.Location = new Point(ManaRegenLbl.Location.X, ManaRegenLbl.Location.Y - 70);
                Res15.Location = new Point(Res15.Location.X, Res15.Location.Y - 70);
                Res16.Location = new Point(Res16.Location.X, Res16.Location.Y - 70);
                ManaRegenPerLvLbl.Visible = false;
                Res17.Visible = false;
                Res18.Visible = false;

                AtkStatsLbl.Location = new Point(AtkStatsLbl.Location.X, AtkStatsLbl.Location.Y - 90);
                AtkDmgLbl.Location = new Point(AtkDmgLbl.Location.X, AtkDmgLbl.Location.Y - 90);
                Res19.Location = new Point(Res19.Location.X, Res19.Location.Y - 90);
                Res20.Location = new Point(Res20.Location.X, Res20.Location.Y - 90);
                AtkDmgPerLvLbl.Visible = false;
                Res21.Visible = false;
                Res22.Visible = false;
                AtkRangeLbl.Location = new Point(AtkRangeLbl.Location.X, AtkRangeLbl.Location.Y - 110);
                Res23.Location = new Point(Res23.Location.X, Res23.Location.Y - 110);
                Res24.Location = new Point(Res24.Location.X, Res24.Location.Y - 110);
                AtkSpdLbl.Location = new Point(AtkSpdLbl.Location.X, AtkSpdLbl.Location.Y - 110);
                Res25.Location = new Point(Res25.Location.X, Res25.Location.Y - 110);
                Res26.Location = new Point(Res26.Location.X, Res26.Location.Y - 110);
                AtkSpdPerLvLbl.Visible = false;
                Res27.Visible = false;
                Res28.Visible = false;

                ArmorStatsLbl.Location = new Point(ArmorStatsLbl.Location.X, ArmorStatsLbl.Location.Y - 130);
                ArmorLbl.Location = new Point(ArmorLbl.Location.X, ArmorLbl.Location.Y - 130);
                Res29.Location = new Point(Res29.Location.X, Res29.Location.Y - 130);
                Res30.Location = new Point(Res30.Location.X, Res30.Location.Y - 130);
                ArmorPerLvLbl.Visible = false;
                Res31.Visible = false;
                Res32.Visible = false;

                MagicStatsLbl.Location = new Point(MagicStatsLbl.Location.X, MagicStatsLbl.Location.Y - 150);
                MagicResistanceLbl.Location = new Point(MagicResistanceLbl.Location.X, MagicResistanceLbl.Location.Y - 150);
                Res33.Location = new Point(Res33.Location.X, Res33.Location.Y - 150);
                Res34.Location = new Point(Res34.Location.X, Res34.Location.Y - 150);
                MagicResistancePerLvLbl.Visible = false;
                Res35.Visible = false;
                Res36.Visible = false;

                MovementSpdLbl.Location = new Point(MovementSpdLbl.Location.X, MovementSpdLbl.Location.Y - 170);
                Res37.Location = new Point(Res37.Location.X, Res37.Location.Y - 170);
                Res38.Location = new Point(Res38.Location.X, Res38.Location.Y - 170);

                CoolStatsLbl.Location = new Point(CoolStatsLbl.Location.X, CoolStatsLbl.Location.Y - 175);
                QCoolLbl.Location = new Point(QCoolLbl.Location.X, QCoolLbl.Location.Y - 175);
                Res39.Location = new Point(Res39.Location.X, Res39.Location.Y - 175);
                Res40.Location = new Point(Res40.Location.X, Res40.Location.Y - 175);
                WCoolLbl.Location = new Point(WCoolLbl.Location.X, WCoolLbl.Location.Y - 175);
                Res41.Location = new Point(Res41.Location.X, Res41.Location.Y - 175);
                Res42.Location = new Point(Res42.Location.X, Res42.Location.Y - 175);
                ECoolLbl.Location = new Point(ECoolLbl.Location.X, ECoolLbl.Location.Y - 175);
                Res43.Location = new Point(Res43.Location.X, Res43.Location.Y - 175);
                Res44.Location = new Point(Res44.Location.X, Res44.Location.Y - 175);
                RCoolLbl.Location = new Point(RCoolLbl.Location.X, RCoolLbl.Location.Y - 175);
                Res45.Location = new Point(Res45.Location.X, Res45.Location.Y - 175);
                Res46.Location = new Point(Res46.Location.X, Res46.Location.Y - 175);
                AdvancedStatsBtn.Text = @"Show Advanced Stats";
            }

        }
    }
}
