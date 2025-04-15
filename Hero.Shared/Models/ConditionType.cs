using Microsoft.EntityFrameworkCore;

namespace Hero.Shared.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class ConditionType
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public virtual IEnumerable<Condition> Conditions { get; set; } = new List<Condition>();

    }
}
