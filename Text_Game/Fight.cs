using System.Data;
using MySql.Data.MySqlClient;

namespace Text_Game
{
    class Fight
    {
        private Player _Player;
        private IEnemy _Enemy;

        public Fight(Player player)
        {
            _Player = player;
            _Enemy = GetEnemy();
        }

        public bool Start()
        {
            bool gameover = false;

            if (_Enemy != null)
            {
                bool end = false;

                while (!end)
                {
                    bool defend = PlayerAttack();

                    if (_Enemy.HP < 1)
                    {
                        end = true;
                        break;
                    }

                    bool attack = true;

                    if (!defend)
                        attack = PlayerMove();

                    if (attack)
                        EnemyAttack(defend);

                    if (_Player.HP < 1)
                    {
                        end = true;
                        gameover = true;
                        break;
                    }
                }

                if (gameover)
                {
                    Console.WriteLine("\nYou lose");
                }

                else
                {
                    Console.WriteLine("\nYou win");
                }
            }

            else
                Console.WriteLine("Something wrong. Enemy doesn't found");

            return gameover;
        }

        private bool PlayerAttack()
        {
            bool defend = false;
            bool end = false;
            Console.WriteLine($"You have {_Player.Stamina} stamina");
            Console.WriteLine("1 - Attack\n2 - Defend\n3 - Rest");

            while (!end)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        if (_Player.Stamina > 0)
                        {
                            _Player.Stamina -= 1;
                            int damage = _Player.Damage;

                            if (_Player.Sword != null)
                                damage += _Player.Sword.Damage;

                            damage -= _Enemy.Defend;

                            if (damage < 1)
                                damage = 1;

                            _Enemy.HP -= damage;

                            Console.WriteLine($"You attack {_Enemy.Name}\nEnemy hp now {_Enemy.HP}");
                        }

                        else
                            Console.WriteLine("You move to enemy, but you haven't stamina for attack");

                        end = true;

                        break; 
                    
                    case ConsoleKey.D2:
                        Console.WriteLine("You're defending. +1 Stamina");

                        if (_Player.Sheald == null)
                            Console.WriteLine("You heven't sheald, stupid!");

                        _Player.Stamina += 1;
                        
                        defend = true;
                        end = true;

                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("You take rest +5 Stamina + 1 HP");
                        _Player.Stamina += 5;
                        _Player.HP += 1;

                        end = true;

                        break;
                }
            }

            return defend;
        }

        private bool PlayerMove()
        {
            bool attack = true;
            Random rand = new Random();

            Console.WriteLine("Left or Right?");

            int place = rand.Next(2);
            ConsoleKey key = Console.ReadKey().Key;

            if (place == 0 && key == ConsoleKey.LeftArrow || place == 1 && key == ConsoleKey.RightArrow)
            {
                Console.WriteLine("You move to another side, that enemy jumped. +2 stamina");
                attack = false;
                _Player.Stamina += 2;
            }

            return attack;
        }

        private void EnemyAttack(bool defend)
        {
            int damage = _Enemy.Damage;

            if (_Player.Sheald != null && defend)
                damage -= _Player.Sheald.Defend;

            if (damage < 1)
                damage = 1;

            _Player.HP -= damage;

            Console.WriteLine($"{_Enemy.Name} attack you\nYour hp now {_Player.HP}");
        }

        private IEnemy GetEnemy()
        {
            Random rand = new Random();

            switch(rand.Next(2) + 1)
            {
                case 1:
                    return new Fox();

                case 2:
                    return new Wolf();

                default:
                    return null;
            }
        }
    }
}
