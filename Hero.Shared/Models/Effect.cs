using Hero.Shared.Models;

public class Effect
{
    public int Id { get; set; }
    public int? Value { get; set; }

    public int EffectTypeId { get; set; }
    public virtual required EffectType EffectType { get; set; }

    public int? OutcomeId { get; set; }
    public virtual Outcome? Outcome { get; set; }
}
