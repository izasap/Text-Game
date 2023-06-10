using System;
using System.Globalization;
using System.Net.NetworkInformation;

namespace Guide
{
    interface ISwords
    {
        string Name { get; }
        string TName { get; }
        int Damage { get; }
    }

    interface IShealds
    {
        string Name { get; }
        string TName { get; }
        int Defend { get; }
    }

    class NoneSword : ISwords
    {
        public string Name { get; }
        public string TName { get; }
        public int Damage { get; }

        public NoneSword()
        {
            Name = "отсутствует";
            TName = "ничего";
            Damage = 0;
        }
    }

    class Wood : ISwords
    {
        public string Name { get; }
        public string TName { get; }
        public int Damage { get; }

        public Wood()
        {
            Name = "палка";
            TName = "палку";
            Damage = 1;
        }
    }

    class Pipe : ISwords
    {
        public string Name { get; }
        public string TName { get; }
        public int Damage { get; }

        public Pipe()
        {
            Name = "труба";
            TName = "трубу";
            Damage = 3;
        }
    }

    class NoneSheald : IShealds
    {
        public string Name { get; }
        public string TName { get; }
        public int Defend { get; }

        public NoneSheald()
        {
            Name = "отсутствует";
            TName = "ничего";
            Defend = 0;
        }
    }

    class Wooden : IShealds
    {
        public string Name { get; }
        public string TName { get; }
        public int Defend { get; }

        public Wooden()
        {
            Name = "дощечка";
            TName = "дощечку";
            Defend = 2;
        }
    }

    class WidePipe : IShealds
    {
        public string Name { get; }
        public string TName { get; }
        public int Defend { get; }

        public WidePipe()
        {
            Name = "половина широкой трубы";
            TName = "половину широкой трубы";
            Defend = 5;
        }
    }
}
