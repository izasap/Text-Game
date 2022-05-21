using System;
using System.IO;

namespace Guide
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0, y = 0;
            bool end = false;
            string[,] pos = new string[10, 10];
            Random rand = new();
            Difficul difficul = new();
            Fight fight = new();
            difficul.Get();

            while (!end)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        y = y == 0 ? y : y = y - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        x = x == 9 ? x : x = x + 1;
                        break;
                    case ConsoleKey.DownArrow:
                        y = y == 9 ? y : y = y + 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        x = x == 0 ? x : x = x - 1;
                        break;
                    case ConsoleKey.Escape:
                        end = !end;
                        break;
                }

                Console.Clear();

                for (int p1 = 0; p1 < 10; p1++)
                {
                    for (int p2 = 0; p2 < 10; p2++)
                    {
                        pos[p1, p2] = p1 == y && p2 == x ? "@" : ".";

                        switch(p2 == 9)
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

                if (difficul.enemy[x, y])
                {
                    Console.WriteLine("Вы наткнулись на врага ");
                    fight.Start();
                    
                }

                else if (difficul.item[x, y])
                {
                    Console.WriteLine("Item here");
                }
            }
        }
    }
}