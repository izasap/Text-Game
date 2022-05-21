using System;

namespace Guide
{
    class Fight
    {
        public bool fight = true;
        public int turn = 0;
        readonly Player player = new();
        readonly Volf volf = new();
        readonly Random rand = new();
        public void Start()
        {
            player.Get();
            volf.Get();
            fight = true;
            turn = 0;

            while (fight)
            {
                if (volf.HP < 1 || player.HP < 1)
                {
                    fight = !fight;

                    if(volf.HP < 1)
                    {
                        Console.WriteLine("Вы выиграли!");
                    }

                    else
                    {
                        Console.WriteLine("Uuuuuuu. U Suck!");
                    }
                }

                else
                {
                    switch (turn)
                    {
                        case 0:
                            T0();
                            break;
                        case 1:
                            T1();
                            break;
                        case 2:
                            T2();
                            break;
                    }
                }
            }
        }

        void T0()
        {
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    volf.HP = volf.Defend < player.Damage ? volf.HP - (player.Damage - volf.Defend) : volf.HP = volf.HP - 1;
                    turn++;
                    break;
                case ConsoleKey.D2:
                    fight = !fight;
                    break;
            }

            Console.WriteLine($"У врага осталось {volf.HP}");
            Console.WriteLine($"Ход {turn}");
            Console.WriteLine("");
        }

        void T1()
        {
            int swipe = rand.Next(2);

            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    turn = swipe == 0 ? 0 : 2;
                    break;
                case ConsoleKey.RightArrow:
                    turn = swipe == 1 ? 0 : 2;
                    break;
            }

            switch(turn)
            {
                case 0:
                    Console.WriteLine("Вы уклонились");
                    break;
                case 2:
                    Console.WriteLine("X(");
                    break;
            }

            Console.WriteLine($"Ход {turn}");
            Console.WriteLine("");
        }

        void T2()
        {
            player.HP = player.Defend < volf.Damage ? player.HP - (volf.Damage - player.Defend) : player.HP = player.HP - 1;
            turn = 0;
            Console.WriteLine($"У вас осталось {player.HP} здоровья");
            Console.WriteLine($"Ход {turn}");
            Console.WriteLine("");
        }
    }
}
