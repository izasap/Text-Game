using System;
using System.IO;

namespace Guide
{
    class Stats
    {
        public string[] stats { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int LVL { get; set; }
        public int XP { get; set; }
        public int Defend { get; set; }
        public int Stamina { get; set; }
        public int Damage { get; set; }
        public int Geo { get; set; }
        public string Sword { get; set; }
        public string Sheald { get; set; }
    }

    class Player : Stats
    {
        public void Get()
        {
            stats = File.ReadAllLines(@"Archive\Player.txt");
            HP = int.Parse(stats[0]);
            LVL = int.Parse(stats[1]);
            XP = int.Parse(stats[2]);
            Defend = int.Parse(stats[3]);
            Stamina = int.Parse(stats[4]);
            Damage = int.Parse(stats[5]);
            Geo = int.Parse(stats[6]);
            Sword = stats[7];
            Sheald = stats[8];

            switch (Sword)
            {
                case "wood":
                    Damage += 2;
                    break;
            }

            switch (Sheald)
            {
                case "wooden":
                    Defend += 1;
                    break;
            }
        }
    }

    class Enemy : Stats
    {
        public void Get()
        {
            Random rand = new Random();
            string[] names = File.ReadAllLines(@"Archive\Names.txt");
            stats = File.ReadAllLines($@"Archive\{Name = names[rand.Next(names.Length)]}.txt");
            HP = int.Parse(stats[0]);
            Defend = int.Parse(stats[1]);
            Damage = int.Parse(stats[2]);
            Geo = int.Parse(stats[3]);
        }
    }
}
