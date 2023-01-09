using System;

namespace Guide
{
    class Fight
    {
        public bool fight = true;
        public int turn = 0;
        readonly Player player = new();
        readonly Enemy enemy = new();
        readonly Random rand = new();
        readonly Difficul difficul = new();
        public void Start(int x, int y)
        {
            player.Get();
            enemy.Get();
            fight = true;
            turn = 0;

            while (fight)
            {
                if (enemy.HP < 1 || player.HP < 1)
                {
                    fight = !fight;

                    if(enemy.HP < 1)
                    {
                        Console.WriteLine("Вы выиграли!");
                        difficul.enemy[x, y] = false;
                        //difficul.Delete("enemy", x, y);
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
                    enemy.HP = enemy.Defend < player.Damage ? enemy.HP - (player.Damage - enemy.Defend) : enemy.HP = enemy.HP - 1;
                    turn++;
                    break;
                case ConsoleKey.D2:
                    fight = !fight;
                    break;
            }

            Console.WriteLine($"У врага осталось {enemy.HP}");
            Console.WriteLine($"Ход {turn}\n");
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

            Console.WriteLine($"Ход {turn}\n");
        }

        void T2()
        {
            player.HP = player.Defend < enemy.Damage ? player.HP - (enemy.Damage - player.Defend) : player.HP = player.HP - 1;
            turn = 0;
            Console.WriteLine($"У вас осталось {player.HP} здоровья");
            Console.WriteLine($"Ход {turn}\n");
        }
    }
}
