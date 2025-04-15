namespace Hero.Shared.Models
{
    public class Stats
    {
        public int Id { get; set; }
        public int Strength { get; set; }
        public int Vitality { get; set; }
        public int Defense { get; set; }
        public int Knowledge { get; set; }
        public int Charisma { get; set; }
        public int Dexterity { get; set; }

        public int? PlayerId { get; set; }
        public virtual Player? Player { get; set; }
        public int? ItemId { get; set; }
        public virtual Item? Item { get; set; }

        public Stats(int strength = 0, int vitality = 0, int defense = 0, int knowledge = 0, int charisma = 0, int dexterity = 0)
        {
            Strength = strength;
            Vitality = vitality;
            Defense = defense;
            Knowledge = knowledge;
            Charisma = charisma;
            Dexterity = dexterity;
        }
    }
}
