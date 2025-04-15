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
        public static Condition DefenseAbove(int value) =>
            new()
            {
                ConditionType = new ConditionType { Name = "TestDefenseAbove" },
                Value = value
            };
        public static Condition DexterityAbove(int value) =>
            new()
            {
                ConditionType = new ConditionType { Name = "TestDexterityAbove" },
                Value = value
            };
        public static Condition KnowledgeAbove(int value) =>
            new()
            {
                ConditionType = new ConditionType { Name = "TestKnowledgeAbove" },
                Value = value
            };
        public static Condition VitalityAbove(int value) =>
            new()
            {
                ConditionType = new ConditionType { Name = "TestVitalityAbove" },
                Value = value
            };
        public static Condition CharismaAbove(int value) =>
            new()
            {
                ConditionType = new ConditionType { Name = "TestCharismaAbove" },
                Value = value
            };
    }
}
