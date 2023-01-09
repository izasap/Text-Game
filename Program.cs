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
            bool end = false;
            Difficul difficul = new();
            Random rand = new();
            Fight fight = new();
            Loot loot = new();
            difficul.Get();

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
                bool item = false, enemy = false;
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
                        string[] stats = File.ReadAllLines(@"Archive\Player.txt");
                        for (int i = 0; i < stats.Length; i++)
                            Console.WriteLine(stats);
                        break;
                    case ConsoleKey.Escape:
                        end = !end;
                        break;
                }

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

                        switch(p2 == 11)
                        {
                            case true:
                                Console.WriteLine(pos[p1, p2]);
                                break;
                            case false:
                                Console.Write(pos[p1, p2]);
                                break;
                        }

                        //uncomplite start

                        /*string path = @"";
                        char[] dif = new char[File.ReadAllText(path).Length];
                        int space = 0, nx = 0, ny = 0;
                        string difs = "";

                        for (int i = 0; i < path.Length; i++)
                        {
                            dif[i] = File.ReadAllText(path)[i];
                            if (dif[i] == ' ')
                            {
                                i++;
                                space++;
                            }

                            else if (space == 0)
                                difs += dif[i];
                        }*/


                        //uncomplite end
                    }
                }

                if (difficul.enemy[x, y])
                {
                    Console.WriteLine("Вы наткнулись на врага ");
                    fight.Start(x, y);
                    
                }

                else if (difficul.item[x, y])
                {
                    Console.WriteLine("Item here");
                    Console.WriteLine(x + " " + y);
                    loot.Find(x, y);
                }
            }
        }
    }
}