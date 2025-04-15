using Microsoft.EntityFrameworkCore;

namespace Hero.Shared.Models
{
    [Index(nameof(Name), IsUnique = true)]

    public class EffectType
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public virtual IEnumerable<Effect> Effects { get; set; } = new List<Effect>();
    }
}
