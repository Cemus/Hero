namespace Hero.Shared.Dtos
{
    public class EffectDto
    {
        public int Id { get; set; }
        public int? Value { get; set; }

        public required EffectTypeDto EffectType { get; set; }
    }
}
