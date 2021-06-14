// ChampionsComparator.Champion2
using System.Collections.Generic;

public class Champion2
{
	public class Image
	{
		public string full { get; set; }

		public string sprite { get; set; }

		public string group { get; set; }

		public double x { get; set; }

		public double y { get; set; }

		public double w { get; set; }

		public double h { get; set; }
	}

	public class Skin
	{
		public string id { get; set; }

		public double num { get; set; }

		public string name { get; set; }

		public bool chromas { get; set; }
	}

	public class Info
	{
		public double attack { get; set; }

		public double defense { get; set; }

		public double magic { get; set; }

		public double difficulty { get; set; }
	}

	public class Stats
	{
		public double hp { get; set; }

		public double hpperlevel { get; set; }

		public double mp { get; set; }

		public double mpperlevel { get; set; }

		public double movespeed { get; set; }

		public double armor { get; set; }

		public double armorperlevel { get; set; }

		public double spellblock { get; set; }

		public double spellblockperlevel { get; set; }

		public double attackrange { get; set; }

		public double hpregen { get; set; }

		public double hpregenperlevel { get; set; }

		public double mpregen { get; set; }

		public double mpregenperlevel { get; set; }

		public double crit { get; set; }

		public double critperlevel { get; set; }

		public double attackdamage { get; set; }

		public double attackdamageperlevel { get; set; }

		public double attackspeedperlevel { get; set; }

		public double attackspeed { get; set; }
	}

	public class Leveltip
	{
		public List<string> label { get; set; }

		public List<string> effect { get; set; }
	}

	public class Datavalues
	{
	}

	public class Spell
	{
		public string id { get; set; }

		public string name { get; set; }

		public string description { get; set; }

		public string tooltip { get; set; }

		public Leveltip leveltip { get; set; }

		public double maxrank { get; set; }

		public List<double> cooldown { get; set; }

		public string cooldownBurn { get; set; }

		public List<double> cost { get; set; }

		public string costBurn { get; set; }

		public Datavalues datavalues { get; set; }

		public List<List<double>> effect { get; set; }

		public List<string> effectBurn { get; set; }

		public List<object> vars { get; set; }

		public string costType { get; set; }

		public string maxammo { get; set; }

		public List<double> range { get; set; }

		public string rangeBurn { get; set; }

		public Image image { get; set; }

		public string resource { get; set; }
	}

	public class Passive
	{
		public string name { get; set; }

		public string description { get; set; }

		public Image image { get; set; }
	}

	public class Champion
	{
		public string id { get; set; }

		public string key { get; set; }

		public string name { get; set; }

		public string title { get; set; }

		public Image image { get; set; }

		public List<Skin> skins { get; set; }

		public string lore { get; set; }

		public string blurb { get; set; }

		public List<string> allytips { get; set; }

		public List<string> enemytips { get; set; }

		public List<string> tags { get; set; }

		public string partype { get; set; }

		public Info info { get; set; }

		public Stats stats { get; set; }

		public List<Spell> spells { get; set; }

		public Passive passive { get; set; }

		public List<object> recommended { get; set; }
	}

	public class Root
	{
		public string type { get; set; }

		public string format { get; set; }

		public string version { get; set; }

		public Dictionary<string, Champion> data { get; set; }
	}
}
