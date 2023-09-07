using System.Data;

using MySql.Data.MySqlClient;

using Text_Game.Plyaer;

namespace Text_Game
{
    class Player
    {
        public uint Id { get; set; } = 0;
        private string _Login { get; set; } = "";
        private string _Password { get; set; } = "";
        public IClasses Class { get; set; } = null;
        public uint Level { get; set; } = 0;
        public ulong XP { get; set; } = 0;
        public int HP { get; set; } = 0;
        public int Stamina { get; set; } = 0;
        public int Damage { get; set; } = 0;
        public int Defend { get; set; } = 0;
        public ISword Sword { get; set; } = null;
        public ISheald Sheald { get; set; } = null;

        public void GetPlayer(DataRow stats)
        {
            switch ((string)stats[3])
            {
                case "warrior":
                    Class = new Warrior();

                    break;

                case "tank":
                    Class = new Tank();

                    break;
            }

            if (stats[10] is not DBNull)
                GetItem((string)stats[10]);

            if (stats[11] is not DBNull)
                GetItem((string)stats[11]);

            Id = (uint)stats[0];
            _Login = (string)stats[1];
            _Password = (string)stats[2];
            Level = (uint)stats[4];
            XP = (ulong)stats[5];
            HP = (int)stats[6];
            Stamina = (int)stats[7];
            Damage = (int)stats[8] + Class.Damage + Sword.Damage;
            Defend = (int)stats[9] + Class.Defend + Sheald.Defend;
        }

        public void CreatePlayer(MySqlConnection connection, string login, string pass, string playerClass)
        {
            MySqlCommand getId = new MySqlCommand("SELECT * FROM `Players`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(getId);
            DataTable players = new DataTable();
            adapter.Fill(players);

            Id = (uint)players.Rows.Count + 1;
            _Login = login;
            _Password = pass;
            Level = 1;
            XP = 0;
            HP = 45;
            Stamina = 15;
            Damage = 1;
            Defend = 0;

            switch (playerClass)
            {
                case "warrior":
                    Class = new Warrior();

                    break;

                case "tank":
                    Class = new Tank();

                    break;
            }

            MySqlCommand createPlayer = new MySqlCommand("INSERT INTO `Players` (`Id`, `Login`, `Password`, `Class`, `Level`, `XP`, `HP`, `Stamina`, `Damage`, `Defend`) VALUES (@id, @login, @pass, @class, @level, @xp, @hp, @stamina, @damage, @defend)", connection);
            createPlayer.Parameters.Add("@id", MySqlDbType.UInt32).Value = Id;
            createPlayer.Parameters.Add("@login", MySqlDbType.Text).Value = _Login;
            createPlayer.Parameters.Add("@pass", MySqlDbType.Text).Value = _Password;
            createPlayer.Parameters.Add("@class", MySqlDbType.Text).Value = Class.Name;
            createPlayer.Parameters.Add("@level", MySqlDbType.Text).Value = Level;
            createPlayer.Parameters.Add("@xp", MySqlDbType.Text).Value = XP;
            createPlayer.Parameters.Add("@hp", MySqlDbType.Text).Value = HP;
            createPlayer.Parameters.Add("@stamina", MySqlDbType.Text).Value = Stamina;
            createPlayer.Parameters.Add("@damage", MySqlDbType.Text).Value = Damage;
            createPlayer.Parameters.Add("@defend", MySqlDbType.Text).Value = Defend;

            connection.Open();

            if (createPlayer.ExecuteNonQuery() != 0)
                Console.WriteLine("\nYou were registered\n");

            else
                Console.WriteLine("\nSomething is wrong\n");

            connection.Close();
        }

        public bool GetItem(string itemname)
        {
            Console.WriteLine($"You found a {itemname}");
            Console.WriteLine("Do you want pickup it?\n Y - yes\n N - no");
            bool end = false;
            bool pickup = false;

            while (!end)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.Y)
                {
                    pickup = true;

                    switch (itemname)
                    {
                        case "wood":
                            Sword = new Wood();

                            break;

                        case "plate":
                            Sheald = new Plate();

                            break;
                    }

                    Console.WriteLine($"You pickup a {itemname}");
                    end = true;
                }

                else if (key == ConsoleKey.N)
                    end = true;
            }

            return pickup;
        }

        public string StatsUpdate()
        {

            string stat = "";
            string[] stats = new string[9];
            stats[0] = "Class: " + Class.Name;
            stats[1] = "Level: " + Level.ToString();
            stats[2] = "XP: " + XP.ToString();
            stats[3] = "HP: " + HP.ToString();
            stats[4] = "Stamina: " + Stamina.ToString();
            stats[5] = "Damage: ";
            stats[6] = "Defend: ";
            stats[7] = "Sword: ";
            stats[8] = "Sheald: ";

            if (Sword != null)
            {
                stats[5] += (Damage + Sword.Damage).ToString();
                stats[7] += Sword.Name;
            }

            else
            {
                stats[5] += Damage.ToString();
                stats[7] += "nothing";
            }

            if (Sheald != null)
            {
                stats[6] += (Defend + Sheald.Defend).ToString();
                stats[8] += Sheald.Name;
            }

            else
            {
                stats[6] += Defend.ToString();
                stats[8] += "nothing";
            }

            for (int i = 0; i < stats.Length; i++)
                stat += stats[i] + "\n";

            return stat;
        }
    }
}
