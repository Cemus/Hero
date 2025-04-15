
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Hero.Shared.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Player
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required int JobId { get; set; }
        public virtual required Job Job { get; set; }
        public required int StatsId { get; set; }
        public virtual required Stats Stats { get; set; }
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
        public Player() { }

        [SetsRequiredMembers]
        public Player(string name, Stats stats, Job job)
        {
            Name = name;
            Stats = stats;
            Job = job;
        }
    }
}
