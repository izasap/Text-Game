namespace Text_Game.Plyaer
{
    interface IClasses
    {
        public string Name { get; }
        public Type Type { get; }
        public int Damage { get; }
        public int Defend { get; }

        public abstract List<string> Ability(params string[] parametrs);
    }

    enum Type : byte
    {
        Warrior = 0,
        Tank = 1
    }

    class Warrior : IClasses
    {
        public string Name { get; } = "warrior";
        public Type Type { get; } = Type.Warrior;
        public int Damage { get; } = 2;
        public int Defend { get; } = 0;

        public List<string> Ability(params string[] parametrs)
        {
            List<string> test = new List<string>();
            test.Add(Name);

            return test;
        }
    }

    class Tank : IClasses
    {
        public string Name { get; } = "tank";
        public Type Type { get; } = Type.Tank;
        public int Damage { get; } = 0;
        public int Defend { get; } = 2;

        public List<string> Ability(params string[] parametrs)
        {
            List<string> test = new List<string>();
            test.Add(Name);

            return test;
        }
    }
}
