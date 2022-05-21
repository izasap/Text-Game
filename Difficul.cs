using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guide
{
    internal class Difficul
    {
        readonly Random rand = new();
        int[,] difficul = new int[10, 10];
        public bool[,] enemy = new bool[10, 10];
        public bool[,] item = new bool[10, 10];
        public void Get()
        {
            for (int p1 = 0; p1 < difficul.GetLength(0); p1++)
            {
                for (int p2 = 0; p2 < difficul.GetLength(1); p2++)
                {
                    difficul[p1, p2] = rand.Next(20);
                    enemy[p1, p2] = difficul[p1, p2] == 17 || difficul[p1, p2] == 18 || difficul[p1, p2] == 19 ? true : false;
                    item[p1, p2] = difficul[p1, p2] == 3 || difficul[p1, p2] == 2 || difficul[p1, p2] == 1 || difficul[p1, p2] == 0 ? true : false;
                }
            }
        }
    }
}
