namespace Hero.Shared.Models
{
    public class PlayerChoiceHistory
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public virtual required Player Player { get; set; }

        public int ChoiceId { get; set; }
        public virtual required Choice Choice { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

}
