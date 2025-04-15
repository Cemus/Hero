using Hero.Shared.Models;

namespace Hero.API.Factories
{
    public class ConditionFactory
    {
        public static Condition StrengthAbove(int value) =>
            new()
            {
                ConditionType = new ConditionType { Name = "TestStrengthAbove" },
                Value = value
            };
    }
}
