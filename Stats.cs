using System;
using System.IO;

namespace Guide
{
    internal class Stats
    {
        public string Path { get; set; }
        public int HP { get; set; }
        public int LVL { get; set; }
        public int XP { get; set; }
        public int Defend { get; set; }
        public int Stamina { get; set; }
        public int Damage { get; set; }
        public int Geo { get; set; }
    }

    class Player : Stats
    {
        public void Get()
        {
            Path = @"H:\VS\Guide\bin\Debug\net6.0\Archive\Player.txt";
            HP = int.Parse(File.ReadAllLines(Path)[0]);
            LVL = int.Parse(File.ReadAllLines(Path)[1]);
            XP = int.Parse(File.ReadAllLines(Path)[2]);
            Defend = int.Parse(File.ReadAllLines(Path)[3]);
            Stamina = int.Parse(File.ReadAllLines(Path)[4]);
            Damage = int.Parse(File.ReadAllLines(Path)[5]);
            Geo = int.Parse(File.ReadAllLines(Path)[6]);
        }
    }

    class Volf : Stats
    {
        public void Get()
        {
            Path = @"H:\VS\Guide\bin\Debug\net6.0\Archive\Volf.txt";
            HP = int.Parse(File.ReadAllLines(Path)[0]);
            Defend = int.Parse(File.ReadAllLines(Path)[1]);
            Damage = int.Parse(File.ReadAllLines(Path)[2]);
            Geo = int.Parse(File.ReadAllLines(Path)[3]);
        }
    }
}
