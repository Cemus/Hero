namespace Hero.Shared.Dtos
{
    public class ConditionDto
    {
        public int Id { get; set; }
        public int? Value { get; set; }
        public required ConditionTypeDto ConditionType { get; set; }
    }
}
