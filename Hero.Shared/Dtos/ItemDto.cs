namespace Hero.Shared.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Type { get; set; }

        public StatsDto? Stats { get; set; }
    }
}
