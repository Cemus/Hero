using Microsoft.EntityFrameworkCore;

namespace Hero.Shared.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Scene
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }

        public virtual ICollection<Choice> Choices { get; set; } = new List<Choice>();
        public virtual ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
