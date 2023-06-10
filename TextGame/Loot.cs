using System;
using System.Net.Security;

namespace Guide
{
    class Loot
    {
        public Loot(Difficult difficult)
        {
            Difficult = difficult;
        }

        private Difficult Difficult;
        Player player = new();
        string[] stats = File.ReadAllLines(@"Archive\Player.txt");

        public void Find(int x, int y)
        {
            Random rand = new();
            int item = rand.Next(2);

            if (item == 0)
            {
                ISwords sword = new NoneSword();

                switch (rand.Next(2))
                {
                    case 0:
                        sword = new Wood();
                        break;

                    case 1:
                        sword = new Pipe();
                        break;
                }

                Console.WriteLine($"Вы нашли {sword.TName}, взять?");
                stats[7] = Sword(sword, x, y);
            }

            else
            {
                IShealds sheald = new NoneSheald();
                int level = 0;

                if (player.Level > 2)
                    level = 2;
                else
                    level = player.Level;
                    
                switch (rand.Next(level))
                {
                    case 0:
                        sheald = new Wooden();
                        break;
                    case 1:
                        sheald = new WidePipe();
                        break;
                }

                Console.WriteLine($"Вы нашли {sheald.TName}, взять?");
                stats[8] = Sheald(sheald, x, y);
            }

            File.WriteAllLines(@"Archive\Player.txt", stats);
        }

        string Sword(ISwords sword, int x, int y)
        {
            bool end = false;
            string loot = stats[7];

            while (!end)
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        loot = sword.Name;
                        Difficult.item[x, y] = false;
                        end = true;
                        Console.WriteLine($"Вы взяли {sword.TName}, которая очень удобно ложится вам в руку");
                        break;
                    case ConsoleKey.E:
                        end = true;
                        Console.WriteLine($"Вы решили не брать {sword.TName}");
                        break;
                }

            return loot;
        }

        string Sheald(IShealds sheald, int x, int y)
        {
            bool end = false;
            string loot = stats[8];

            while (!end)
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        loot = sheald.Name;
                        Difficult.item[x, y] = false;
                        end = true;
                        Console.WriteLine($"Вы взяли {sheald.TName}. Поблизости лежали верёвки, которыми вы привязали трубу к руке");
                        break;
                    case ConsoleKey.E:
                        end = true;
                        Console.WriteLine($"Вы решили не брать {sheald.TName} и не возится с ней");
                        break;
                }

            return loot;
        }
    }
}
