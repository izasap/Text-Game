using System.Diagnostics.Contracts;

namespace Text_Game
{
    public interface ISword
    {
        public string Name { get; }
        public int Damage { get; }
    }

    public interface ISheald
    {
        public string Name { get; }
        public int Defend { get; }
    }

    class Wood : ISword
    {
        public string Name { get; } = "Wood";
        public int Damage { get; } = 1;
    }

    class Plate : ISheald
    {
        public string Name { get; } = "Plate";
        public int Defend { get; } = 1;
    }
}
