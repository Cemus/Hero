namespace Hero.Shared.Dtos
{
    public class OutcomeDto
    {
        public required string Label { get; set; }
        public required string FeedBack { get; set; }

        public ICollection<ConditionDto> Conditions { get; set; } = new List<ConditionDto>();
        public ICollection<EffectDto> Effects { get; set; } = new List<EffectDto>();
    }
}
