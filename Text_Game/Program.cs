using System.Data;
using MySql.Data.MySqlClient;

namespace Text_Game
{
    class Program
    {
        private readonly MySqlConnection _Connection = new MySqlConnection("server=b9kx3n0rencc8gzmtnvj-mysql.services.clever-cloud.com;port=3306;username=ujczmzynunivfqhq;password=yesDNSEyJ8Bk1xruFNSY;database=b9kx3n0rencc8gzmtnvj");
        private Player _Player;

        static void Main(string[] args)
            => new Program().Start();

        void Start()
        {
            //Login and Register
            _Player = new Player();
            Console.WriteLine("1 - Login\n2 - Register");
            bool end = false;

            while (!end)
            {
                ConsoleKey choose = Console.ReadKey().Key;

                switch (choose)
                {
                    case ConsoleKey.D1:
                        Login();
                        end = true;

                        break;

                    case ConsoleKey.D2:
                        Register();
                        end = true;

                        break;

                    default:
                        Console.WriteLine("incorrect input");

                        break;
                }
            }

            //Get map
            Map map = new Map();

            for (int i = 0; i < map.Borders.Count; i++)
                Console.WriteLine(map.Borders[i]);

            // Movement
            if (map.Borders.Count != 0)
                Movement(map);
        }

        void Login()
        {
            DataTable table = new DataTable();
            bool end = false;

            while (!end)
            {
                Console.Write("\nLogin: ");
                string login = Console.ReadLine();

                Console.Write("Password: ");
                string pass = Console.ReadLine();

                MySqlCommand selectPlayer = new MySqlCommand("SELECT * FROM `Players` WHERE `Login` = @login AND `Password` = @pass", _Connection);
                selectPlayer.Parameters.Add("@login", MySqlDbType.Text).Value = login;
                selectPlayer.Parameters.Add("@pass", MySqlDbType.Text).Value = pass;
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectPlayer);
                adapter.Fill(table);

                if (table.Rows.Count != 0)
                    end = true;

                else
                    Console.WriteLine("Incorrect login or password");
            }

            _Player.GetPlayer(table.Rows[table.Rows.Count - 1]);
        }

        void Register()
        {
            bool end = false;
            string login = "", pass = "", playerClass = "";

            while (!end)
            {
                Console.Write("\nLogin: ");
                login = Console.ReadLine();

                Console.Write("Password: ");
                pass = Console.ReadLine();

                playerClass = "";

                Console.WriteLine("Choose your class:\n1 - Warrior\n2 - Gunner\n3 - Wizard");
                ConsoleKey classNumber = Console.ReadKey().Key;

                bool classChoosed = false;

                while (!classChoosed)
                {
                    switch (classNumber)
                    {
                        case ConsoleKey.D1:
                            playerClass = "warrior";
                            classChoosed = true;

                            break;

                        case ConsoleKey.D2:
                            playerClass = "tank";
                            classChoosed = true;

                            break;

                        default:
                            Console.WriteLine("incorrect input");

                            break;
                    }
                }

                if (login != "" && pass != "" && playerClass != "")
                    end = true;

                else if (playerClass == "")
                    Console.WriteLine("You must choose correct class");

                else
                    Console.WriteLine("You must write login and password");
            }

            _Player.CreatePlayer(_Connection, login, pass, playerClass);
        }

        void Movement(Map map)
        {
            Random rand = new Random();
            string stats = _Player.StatsUpdate();
            string[] border = map.Borders.ToArray();
            bool end = false;
            int x = map.Spawn_X;
            int y = map.Spawn_Y;

            while (!end)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.W:
                        if (map.Borders[y - 1][x] != '#')
                            y -= 1;

                        break;

                    case ConsoleKey.A:
                        if (map.Borders[y][x - 1] != '#')
                            x -= 1;

                        break;

                    case ConsoleKey.S:
                        if (map.Borders[y + 1][x] != '#')
                            y += 1;

                        break;

                    case ConsoleKey.D:
                        if (map.Borders[y][x + 1] != '#')
                            x += 1;

                        break;

                    case ConsoleKey.Escape:
                        end = true;

                        break;
                }

                border = map.Borders.ToArray();
                border[y] = "";

                for (int i = 0; i < map.Borders.Count; i++)
                {
                    if (i == x)
                        border[y] += "@";

                    else
                        border[y] += map.Borders[y][i];
                }

                Console.Clear();
                string bordering = "";

                for (int i = 0; i < map.Borders.Count; i++)
                    bordering += border[i] + "\n";

                Console.WriteLine(bordering);
                Console.WriteLine($"Your stats:\n\n{stats}");

                if (map.EnemiesPositions[x, y])
                {
                    Console.WriteLine("You find enemy");
                    Fight fight = new Fight(_Player);
                    end = fight.Start();
                    stats = _Player.StatsUpdate();
                    map.EnemiesPositions[x, y] = false;
                }

                else if (map.ItemsPositions[x, y])
                {
                    string itemname = "";

                    switch (rand.Next(2) + 1)
                    {
                        case 1:
                            itemname = "wood";

                            break;

                        case 2:
                            itemname = "plate";

                            break;
                    }

                    if (_Player.GetItem(itemname))
                        map.ItemsPositions[x, y] = false;

                    stats = _Player.StatsUpdate();
                }
            }

            Console.WriteLine("Game over");
        }
    }
}