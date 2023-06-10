using System;
using System.IO;

namespace Guide
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] pos = new char[12, 12];
            int x = 1, y = 1;
            bool end = false, clear = true;
            Difficult difficult = new();
            Random rand = new();
            Fight fight = new(difficult);
            Loot loot = new(difficult);
            Inventory inventory = new();
            difficult.Get();

            Console.WriteLine(@"Перед игрой, рекомендуемо прочитать файл '...\TextGame\Guide.txt', это поможет узнать управление для игры и много другой полезной информации."+"\nПриятной игры!\n");

            for (int p1 = 0; p1 < 12; p1++)
            {
                for (int p2 = 0; p2 < 12; p2++)
                {
                    if (p1 == 0 || p2 == 0 || p1 == 11 || p2 == 11)
                        pos[p1, p2] = '#';
                    else if (p1 == y && p2 == x)
                        pos[p1, p2] = '@';
                    else
                        pos[p1, p2] = '.';

                    switch (p2 == 11)
                    {
                        case true:
                            Console.WriteLine(pos[p1, p2]);
                            break;
                        case false:
                            Console.Write(pos[p1, p2]);
                            break;
                    }
                }
            }

            while (!end)
            {
                clear = true;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        y = y == 1 ? y : y - 1;
                        break;

                    case ConsoleKey.RightArrow:
                        x = x == 10 ? x : x + 1;
                        break;

                    case ConsoleKey.DownArrow:
                        y = y == 10 ? y : y + 1;
                        break;

                    case ConsoleKey.LeftArrow:
                        x = x == 1 ? x : x - 1;
                        break;

                    case ConsoleKey.S:
                        clear = false;
                        Player player = new();
                        Console.WriteLine($"\nЗдоровье: {player.HP} \n" +
                            $"Уровень: {player.Level} \n" +
                            $"Опыт: {player.XP} \n" +
                            $"Выносливость: {player.Stamina} \n" +
                            $"Гео: {player.Geo} \n" +
                            $"Сила: {player.Damage} \n" +
                            $"Защита: {player.Defend} \n" +
                            $"Меч: {player.Sword.Name} \n" +
                            $"Щит: {player.Sheald.Name} \n");
                        break;

                    case ConsoleKey.I:
                        inventory.Show();
                        break;

                    case ConsoleKey.Escape:
                        end = !end;
                        break;
                }

                if (clear)
                {
                    Console.Clear();

                    for (int p1 = 0; p1 < 12; p1++)
                    {
                        for (int p2 = 0; p2 < 12; p2++)
                        {
                            if (p1 == 0 || p2 == 0 || p1 == 11 || p2 == 11)
                                pos[p1, p2] = '#';
                            else if (p1 == y && p2 == x)
                                pos[p1, p2] = '@';
                            else
                                pos[p1, p2] = '.';

                            switch (p2 == 11)
                            {
                                case true:
                                    Console.WriteLine(pos[p1, p2]);
                                    break;
                                case false:
                                    Console.Write(pos[p1, p2]);
                                    break;
                            }
                        }
                    }

                    if (difficult.enemy[x, y])
                    {
                        Console.Write("Вы наткнулись на врага. ");
                        fight.Start(x, y);

                    }

                    else if (difficult.item[x, y])
                    {
                        Console.WriteLine("Item here");
                        loot.Find(x, y);
                    }
                }
            }
        }
    }
}