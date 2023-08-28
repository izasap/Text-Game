namespace Text_Game
{
    public interface IEnemy
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int Damage { get; set; }
        public int Defend { get; set; }
    }

    public class Fox : IEnemy
    {
        public string Name { get; set; } = "Fox";
        public int HP { get; set; } = 5;
        public int Damage { get; set; } = 1;
        public int Defend { get; set; } = 0;
    }

    public class Wolf : IEnemy
    {
        public string Name { get; set; } = "Wolf";
        public int HP { get; set; } = 10;
        public int Damage { get; set; } = 2;
        public int Defend { get; set; } = 1;
    }
}
