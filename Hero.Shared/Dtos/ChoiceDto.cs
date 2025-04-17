namespace Hero.Shared.Dtos
{
    public class ChoiceDto
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required bool IsRepeatable { get; set; }
        public ICollection<OutcomeDto> Outcomes { get; set; } = [];
    }
}
