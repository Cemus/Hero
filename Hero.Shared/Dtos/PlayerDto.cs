namespace Hero.Shared.Dtos

{
    public class PlayerDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required JobDto Job { get; set; }
        public required StatsDto Stats { get; set; }
    }
}
