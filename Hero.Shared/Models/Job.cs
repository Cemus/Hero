using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Hero.Shared.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Job
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; } = new List<Player>();

        [SetsRequiredMembers]
        public Job(string name)
        {
            Name = name;
        }
    }
}
