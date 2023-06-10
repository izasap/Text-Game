using System;

namespace Guide
{
    class Fight
    {
        public bool fight = true;
        public int turn = 0;
        Player player = new();
        IEnemyStats enemy = new Fox();
        readonly Random rand = new();
        readonly Difficult Difficult;
        int HP = 0;
        int EHP = 0;

        public Fight(Difficult difficult)
        {
            Difficult = difficult;
        }

        public void Start(int x, int y)
        {
            fight = true;
            turn = 0;

            switch (rand.Next(player.Level))
            {
                case 1:
                    enemy = new Wolf();
                    break;

                case 2:
                    enemy = new Bear();
                    break;
            }

            HP = player.HP;
            EHP = enemy.HP;

            Console.WriteLine($"Это {enemy.Name}. \n" +
                $"Здоровье: {EHP}\n" +
                $"Опыт за убийство: {enemy.XP}\n" +
                $"Защита: {enemy.Defend}\n" +
                $"Урон: {enemy.Damage}\n" +
                $"Деньги за убийство: {enemy.Geo}");

            while (fight)
            {
                if (EHP < 1 || HP < 1)
                {
                    fight = !fight;

                    if(EHP < 1)
                    {
                        Console.WriteLine("Вы выиграли!");
                        Difficult.enemy[x, y] = false;
                        string[] stats = File.ReadAllLines("Archive/Player.txt");
                        stats[2] += enemy.XP;
                        File.WriteAllLines("Archive/Player.txt", stats);
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
                    EHP = enemy.Defend < player.Damage ? EHP - (player.Damage - enemy.Defend) : EHP  - 1;
                    turn++;
                    break;
                case ConsoleKey.D2:
                    fight = !fight;
                    break;
            }

            Console.WriteLine($"У врага осталось {EHP}");
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
            HP = player.Defend < enemy.Damage ? HP - (enemy.Damage - player.Defend) : HP - 1;
            turn = 0;
            Console.WriteLine($"У вас осталось {HP} здоровья");
            Console.WriteLine($"Ход {turn}\n");
        }
    }
}
