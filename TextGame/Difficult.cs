﻿using System;

namespace Guide
{
    public class Difficult
    {
        readonly Random rand = new();
        int[,] difficul = new int[12, 12];
        public bool[,] enemy = new bool[12, 12];
        public bool[,] item = new bool[12, 12];
        public void Get()
        {
            for (int p1 = 0; p1 < difficul.GetLength(0); p1++)
            {
                for (int p2 = 0; p2 < difficul.GetLength(1); p2++)
                {
                    difficul[p1, p2] = rand.Next(20);
                    switch (difficul[p1, p2])
                    {
                        case 17:
                        case 18:
                        case 19:
                            enemy[p1, p2] = true;
                            break;
                        case 1:
                        case 2:
                        case 3:
                            item[p1, p2] = true;
                            break;
                    }
                }
            }
        }
    }
}