namespace Text_Game
{
    class Map
    {
        public List<string> Borders;

        public int Size_X;
        public int Size_Y;
        public int Spawn_X;
        public int Spawn_Y;

        public bool[,] EnemiesPositions;
        public bool[,] ItemsPositions;

        public Map()
        {
            MapSettings settings = new MapSettings();
            int errcode;
            bool ok;

            ok = settings.Create(out Borders, out Size_X, out Size_Y, out Spawn_X, out Spawn_Y, out errcode);
            ok = ok == true ? settings.Fill(Size_X, Size_Y, out EnemiesPositions, out ItemsPositions, out errcode) : false;

            if (!ok)
                Error(errcode);
        }

        private void Error(int errcode)
        {
            switch (errcode)
            {
                case 1:
                    Console.WriteLine("Map not found");

                    break;

                case 2:
                    Console.WriteLine("Enemies count not found");

                    break;

                case 3:
                    Console.WriteLine("Items count not found");

                    break;
            }
        }
    }

    public class MapSettings
    {
        private string _Path = "";

        public bool Create(out List<string> borders, out int size_x, out int size_y, out int spawn_x, out int spawn_y, out int errcode)
        {
            Console.WriteLine("/-----| Creating map |-----\n|");

            #if RELEASE
            Thread.Sleep(3000);
            #endif

            borders = new List<string>();
            size_x = 0;
            size_y = 0;
            spawn_x = 0;
            spawn_y = 0;
            errcode = 0;

            // Choose map
            Console.WriteLine("| ---| Choosing map |---");

            #if RELEASE
            Thread.Sleep(100);
            #endif

            Random rand = new Random();
            int n = rand.Next(1) + 1;
            _Path = $"Source/Maps/{n}/";
            string mappath = _Path + "Map.txt";
            List<string> walls = new List<string>();

            if (File.Exists(mappath))
                walls = File.ReadAllLines(mappath).ToList();

            else
            {
                errcode = 1;
                return false;
            }

            int x = 0;
            int y = 0;

            // Map size
            Console.WriteLine("| ---| Getting size of map |---");

            #if RELEASE
            Thread.Sleep(100);
            #endif

            bool is_x = true;

            GetXY(walls[0], out x, out y);

            bool[,] is_wall = new bool[x, y];

            // Spawn position
            Console.WriteLine("| ---| Getting spawn position");

            #if RELEASE
            Thread.Sleep(100);
            #endif

            is_x = true;

            GetXY(walls[1], out spawn_x, out spawn_y);

            // Walls position
            Console.WriteLine("| ---| Adding borders |---");

            #if RELEASE
            Thread.Sleep(1000);
            #endif

            for (int i = 2; i < walls.Count; i++)
            {
                int x_wall = 0;
                int y_wall = 0;
                is_x = true;

                GetXY(walls[i], out x_wall, out y_wall);

                is_wall[x_wall, y_wall] = true;
            }

            // Writing walls in map
            Console.WriteLine("| ---| Drawing a map |---");

            #if RELEASE
            Thread.Sleep(2500);
            #endif

            for (int i = 0; i < is_wall.GetLength(0); i++)
            {
                string border = "";

                for (int j = 0; j < is_wall.GetLength(1); j++)
                {
                    if (is_wall[i, j])
                        border += "#";

                    else
                        border += " ";
                }

                borders.Add(border);
            }

            Console.WriteLine("|\n\\-----| Map created |-----\n");

            #if RELEASE
            Thread.Sleep(3000);
            #endif

            size_x = x;
            size_y = y;

            if (errcode == 0)
                return true;

            else
                return false;
        }

        public bool Fill(int size_x, int size_y, out bool[,] enemypos, out bool[,] itempos, out int errcode)
        {
            Console.WriteLine("/ -----| Filling map |-----\n|");

            #if RELEASE
            Thread.Sleep(3000);
            #endif

            int enemiescount = 0;
            int itemscount = 0;
            string enemypath = _Path + "Enemies.txt";
            string itempath = _Path + "Items.txt";

            enemypos = new bool[size_x, size_y];
            itempos = new bool[size_x, size_y];

            errcode = int.TryParse(File.ReadAllLines(enemypath)[0], out enemiescount) == true ? 0 : 2;
            errcode = int.TryParse(File.ReadAllLines(itempath)[0], out itemscount) == true ? 0 : 3;

            if (errcode != 0)
                return false;

            // Getting enemies position
            Console.WriteLine("| ---| Adding enemies |---");

            #if RELEASE
            Thread.Sleep(2000);
            #endif

            for (int i = 1; i < enemiescount + 1; i++)
            {
                int x = 0, y = 0;
                bool is_x = true;
                string pos = File.ReadAllLines(enemypath)[i];

                GetXY(pos, out x, out y);

                enemypos[y, x] = true;
            }

            // Getting items position
            Console.WriteLine("| ---| Adding items |---");

            #if RELEASE
            Thread.Sleep(500);
            #endif

            for (int i = 1; i < itemscount + 1; i++)
            {
                int x = 0, y = 0;
                bool is_x = true;
                string pos = File.ReadAllLines(itempath)[i];

                GetXY(pos, out x, out y);

                itempos[y, x] = true;
            }

            if (errcode == 0)
            {
                Console.WriteLine("|\n\\ -----| Map filled |-----\n");

                #if RELEASE
                Thread.Sleep(3000);
                #endif

                return true;
            }

            else
                return false;
        }

        private void GetXY(string pos, out int x, out int y)
        {
            bool is_x = true;
            x = 0;
            y = 0;

            for (int i = 0; i < pos.Length; i++)
            {
                if (pos[i] == ' ')
                    is_x = false;

                else if (is_x)
                    x = x * 10 + int.Parse(pos[i].ToString());

                else
                    y = y * 10 + int.Parse(pos[i].ToString());
            }
        }
    }
}