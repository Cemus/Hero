namespace Hero.Shared.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required bool IsRepeatable { get; set; } = true;

        public int? SceneId { get; set; }
        public virtual Scene? Scene { get; set; }
        public virtual ICollection<Outcome> Outcomes { get; set; } = new List<Outcome>();


    }
}
