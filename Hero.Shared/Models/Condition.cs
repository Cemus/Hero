using Hero.Shared.Models;

public class Condition
{
    public int Id { get; set; }
    public int? Value { get; set; }
    public int ConditionTypeId { get; set; }
    public virtual required ConditionType ConditionType { get; set; }

    public int? OutcomeId { get; set; }
    public virtual Outcome? Outcome { get; set; }
}
