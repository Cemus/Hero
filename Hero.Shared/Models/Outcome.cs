using System.ComponentModel.DataAnnotations.Schema;

namespace Hero.Shared.Models
{
    [Table("Outcomes")]
    public class Outcome
    {
        public int Id { get; set; }
        public required string Label { get; set; }

        public virtual ICollection<Condition> Conditions { get; set; } = new List<Condition>();
        public virtual ICollection<Effect> Effects { get; set; } = new List<Effect>();
    }
}
