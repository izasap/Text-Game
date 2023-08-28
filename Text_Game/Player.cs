using System.Numerics;
using System.Runtime.CompilerServices;

namespace Text_Game
{
    public class Player
    {
        public int HP { get; set; } = 100;
        public int Stamina { get; set; } = 15;
        public int Damage { get; set; } = 1;
        public int Defend { get; set; } = 0;
        public ISword Sword { get; set; } = null;
        public ISheald Sheald { get; set; } = null;

        public bool GetItem(string itemname)
        {
            Console.WriteLine($"You found a {itemname}");
            Console.WriteLine("Do you want pickup it?\n Y - yes\n N - no");
            bool end = false;
            bool pickup = false;

            while (!end)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.Y)
                {
                    pickup = true;

                    switch (itemname)
                    {
                        case "wood":
                            Sword = new Wood();

                            break;

                        case "plate":
                            Sheald = new Plate();

                            break;
                    }

                    Console.WriteLine($"You pickup a {itemname}");
                    end = true;
                }

                else if (key == ConsoleKey.N)
                    end = true;
            }

            return pickup;
        }

        public string StatsUpdate()
        {
            string stat = "";
            string[] stats = new string[6];
            stats[0] = "HP: " + HP.ToString();
            stats[1] = "Stamina: " + Stamina.ToString();
            stats[2] = "Damage: ";
            stats[3] = "Defend: ";
            stats[4] = "Sword: ";
            stats[5] = "Sheald: ";

            if (Sword != null)
            {
                stats[2] += (Damage + Sword.Damage).ToString();
                stats[4] += Sword.Name;
            }

            else
            {
                stats[2] += Damage.ToString();
                stats[4] += "nothing";
            }

            if (Sheald != null)
            {
                stats[3] += (Defend + Sheald.Defend).ToString();
                stats[5] += Sheald.Name;
            }

            else
            {
                stats[3] += Defend.ToString();
                stats[5] += "nothing";
            }

            for (int i = 0; i < stats.Length; i++)
                stat += stats[i] + "\n";

            return stat;
        }
    }
}
