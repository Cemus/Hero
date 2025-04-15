using Microsoft.EntityFrameworkCore;

namespace Hero.Shared.Models
{
    [Index(nameof(Name), IsUnique = true)]

    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Type { get; set; }

        public int? StatsId { get; set; }
        public virtual Stats? Stats { get; set; }
        public virtual ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
