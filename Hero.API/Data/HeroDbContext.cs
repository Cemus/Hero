using Hero.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hero.API.Data
{
    public class HeroDbContext : DbContext
    {
        public HeroDbContext(DbContextOptions<HeroDbContext> options) : base(options) { }

        public DbSet<Scene> Scenes => Set<Scene>();
        public DbSet<Choice> Choices => Set<Choice>();
        public DbSet<Condition> Conditions => Set<Condition>();
        public DbSet<Outcome> Outcomes => Set<Outcome>();
        public DbSet<ConditionType> ConditionTypes => Set<ConditionType>();
        public DbSet<Effect> Effects => Set<Effect>();
        public DbSet<EffectType> EffectTypes => Set<EffectType>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<Stats> Stats => Set<Stats>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Choice>()
                .HasOne(c => c.Scene)
                .WithMany(s => s.Choices)
                .HasForeignKey(c => c.SceneId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Condition>()
                .HasOne(c => c.ConditionType)
                .WithMany(ct => ct.Conditions)
                .HasForeignKey(c => c.ConditionTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Condition>()
                .HasOne(c => c.Outcome)
                .WithMany(o => o.Conditions)
                .HasForeignKey(c => c.OutcomeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Effect>()
                .HasOne(e => e.Outcome)
                .WithMany(o => o.Effects)
                .HasForeignKey(e => e.OutcomeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Effect>()
                .HasOne(e => e.EffectType)
                .WithMany(et => et.Effects)
                .HasForeignKey(e => e.EffectTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Stats)
                .WithOne(s => s.Player)
                .HasForeignKey<Player>(p => p.StatsId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Job)
                .WithMany(j => j.Players)
                .HasForeignKey(p => p.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Stats)
                .WithOne(s => s.Item)
                .HasForeignKey<Item>(i => i.StatsId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Player>()
                .HasMany(p => p.Items)
                .WithMany(i => i.Players);
        }
    }
}
