using System;

namespace Guide
{
    class Loot
    {
        Player player = new();
        string[] stats;
        public void Find(int x, int y)
        {
            Console.WriteLine(x + " " + y);
            Random rand = new();
            int item = rand.Next(2);
            stats = File.ReadAllLines(@"Archive\Player.txt");

            if (item == 0)
            {
                Console.WriteLine("Вы нашли палку, взять?");
                stats[7] = Sword(x, y);
            }

            else
            {
                Console.WriteLine("Вы нашли деревянный щит, взять?");
                stats[8] = Sheald(x, y);
            }

            File.WriteAllLines(@"Archive\Player.txt", stats);
            player.Get();
        }

        string Sword(int x, int y)
        {
            Difficul difficul = new();
            Console.WriteLine(x + " " + y);
            bool end = false;
            string loot = stats[7];

            while (!end)
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        loot = "wood";
                        difficul.item[x, y] = false;
                        //difficul.Delete("item", x, y);
                        end = true;
                        Console.WriteLine("Вы взяли палку");
                        break;
                    case ConsoleKey.D2:
                        end = true;
                        Console.WriteLine("Вы не взяли предмет");
                        break;
                }

            return loot;
        }

        string Sheald(int x, int y)
        {
            Difficul difficul = new();
            Console.WriteLine(x + " " + y);
            bool end = false;
            string loot = stats[8];

            while (!end)
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        loot = "wooden";
                        difficul.item[x, y] = false;
                        //difficul.Delete("item", x, y);
                        end = true;
                        Console.WriteLine("Вы взяли деревянный щит");
                        break;
                    case ConsoleKey.D2:
                        end = true;
                        Console.WriteLine("Вы не взяли предмет");
                        break;
                }

            return loot;
        }
    }
}
