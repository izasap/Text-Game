using System;
using System.IO;

namespace Guide
{
    class Player
    {
        public int HP { get; }
        public int Level { get; }
        public int XP { get; }
        public int Stamina { get; }
        public int Geo { get; }
        public int Damage { get; }
        public int Defend { get; }
        public ISwords Sword { get; }
        public IShealds Sheald { get; }

        public Player()
        {
            string[] stats = File.ReadAllLines("Archive/Player.txt");
            
            HP = int.Parse(stats[0]);
            Level = int.Parse(stats[1]);
            XP = int.Parse(stats[2]);
            Stamina = int.Parse(stats[3]);
            Geo = int.Parse(stats[4]);

            switch (stats[7])
            {
                case "палка":
                    Sword = new Wood();
                    break;

                default:
                    Sword = new NoneSword();
                    break;
            }

            switch (stats[8])
            {
                case "дощечка":
                    Sheald = new Wooden();
                    break;

                default:
                    Sheald = new NoneSheald();
                    break;
            }

            Damage = int.Parse(stats[5]) + Sword.Damage;
            Defend = int.Parse(stats[6]) + Sheald.Defend;
        }

        void LevelUp(int xp)
        {
            if (Level == 1 && xp >= 50 || Level == 2 && xp >= 100)
            {
                switch (Level)
                {
                    case 1:
                        xp -= 50;
                        break;

                    case 2:
                        xp -= 100;
                        break;
                }

                string[] stats = File.ReadAllLines("Archive/Player.txt");
                int level = Level + 1;

                stats[1] = level.ToString();
                stats[2] = xp.ToString();

                File.WriteAllLines("Archive/Player.txt", stats);
            }
        }
    }
    interface IEnemyStats
    {
        string Name { get; }
        int HP { get; }
        int XP { get; }
        int Damage { get; }
        int Defend { get; }
        int Geo { get; }
    }

    class Fox : IEnemyStats
    {
        public string Name { get; }
        public int HP { get; }
        public int XP { get; }
        public int Geo { get; }
        public int Damage { get; }
        public int Defend { get; }

        public Fox()
        {
            string[] stats = File.ReadAllLines("Archive/Fox.txt");
            Name = "Лиса";
            HP = int.Parse(stats[0]);
            XP = int.Parse(stats[1]);
            Geo = int.Parse(stats[2]);
            Damage = int.Parse(stats[3]);
            Defend = int.Parse(stats[4]);
        }
    }

    class Wolf : IEnemyStats
    {
        public string Name { get; }
        public int HP { get; }
        public int XP { get; }
        public int Geo { get; }
        public int Damage { get; }
        public int Defend { get; }

        public Wolf()
        {
            string[] stats = File.ReadAllLines("Archive/Wolf.txt");
            Name = "Волк";
            HP = int.Parse(stats[0]);
            XP = int.Parse(stats[1]);
            Geo = int.Parse(stats[2]);
            Damage = int.Parse(stats[3]);
            Defend = int.Parse(stats[4]);
        }
    }

    class Bear : IEnemyStats
    {
        public string Name { get; }
        public int HP { get; }
        public int XP { get; }
        public int Geo { get; }
        public int Damage { get; }
        public int Defend { get; }

        public Bear()
        {
            string[] stats = File.ReadAllLines("Archive/Bear.txt");
            Name = "Медведь";
            HP = int.Parse(stats[0]);
            XP = int.Parse(stats[1]);
            Geo = int.Parse(stats[2]);
            Damage = int.Parse(stats[3]);
            Defend = int.Parse(stats[4]);
        }
    }
}
