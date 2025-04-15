using Hero.Shared.Models;

namespace Hero.Shared.Dtos
{
    public class ChoiceDto
    {
        public int Id { get; set; }
        public required string Description { get; set; }

        public ICollection<Outcome> Outcomes { get; set; } = new List<Outcome>();
    }
}
