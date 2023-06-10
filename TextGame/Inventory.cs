using System;
using System.IO;

namespace Guide
{
    class Inventory
    {
        public void Show()
        {
            bool close = false;

            while (!close)
            {
                Player player = new();

                Console.WriteLine($"Меч: {player.Sword.Name}\n" +
                    $"Щит: {player.Sheald.Name}\n\n" +
                    $"1. Изучить меч\n" +
                    $"2. Изучить щит\n" +
                    $"E. Выйти из инвенторя\n");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Sword(player.Sword);
                        break;

                    case ConsoleKey.D2:
                        Sheald(player.Sheald);
                        break;

                    case ConsoleKey.E:
                        close = true;
                        break;
                }

                Console.WriteLine();
            }
        }

        private void Sword(ISwords sword)
        {
            Console.WriteLine($"Меч: {sword.Name}\n" +
                $"Урон: +{sword.Damage}\n\n" +
                $"T. Выбросить меч\n" +
                $"E. Вернутся в инвентарь\n");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.T:
                    string[] stats = File.ReadAllLines("Archive/Player.txt");
                    stats[7] = "none";
                    File.WriteAllLines("Archive/Player.txt", stats);
                    Console.WriteLine($"Вы выбросили {sword.TName}");
                    break;

                case ConsoleKey.E:
                    break;
            }

            Console.WriteLine();
        }

        private void Sheald(IShealds sheald)
        {
            Console.WriteLine($"Щит: {sheald.Name}\n" +
                $"Защита: +{sheald.Defend}\n\n" +
                $"T. Выбросить щит\n" +
                $"E. Вернутся в инвентарь\n");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.T:
                    string[] stats = File.ReadAllLines("Archive/Player.txt");
                    stats[8] = "none";
                    File.WriteAllLines("Archive/Player.txt", stats);
                    Console.WriteLine($"Вы выбросили {sheald.TName}");
                    break;

                case ConsoleKey.E:
                    break;
            }

            Console.WriteLine();
        }
    }
}
