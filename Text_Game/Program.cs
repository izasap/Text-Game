namespace Text_Game
{
    class Program
    {
        static void Main(string[] args)
            => new Program().Start();

        void Start()
        {
            //Get map
            Map map = new Map();

            for (int i = 0; i < map.Borders.Count; i++)
                Console.WriteLine(map.Borders[i]);

            // Movement
            if (map.Borders.Count != 0)
                Movement(map);
        }

        void Movement(Map map)
        {
            Player player = new Player();
            Random rand = new Random();
            string stats = player.StatsUpdate();
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
                    Fight fight = new Fight(player);
                    end = fight.Start();
                    stats = player.StatsUpdate();
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

                    if (player.GetItem(itemname))
                        map.ItemsPositions[x, y] = false;

                    stats = player.StatsUpdate();
                }
            }

            Console.WriteLine("Game over");
        }
    }
}