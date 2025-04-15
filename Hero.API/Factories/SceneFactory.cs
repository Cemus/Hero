using Hero.Shared.Models;

namespace Hero.API.Factories
{
    public static class SceneFactory
    {
        public static Scene CreateScene(string name, string description)
        {
            return new Scene
            {
                Name = name,
                Description = description,
                Choices = new List<Choice>()
            };
        }

        public static void AddBasicChoices(Scene scene)
        {
            scene.Choices.Add(CreateItemPickupChoice(scene));
            scene.Choices.Add(CreateMountainChoice(scene));
        }

        private static Choice CreateItemPickupChoice(Scene scene)
        {
            var effectTypeAddItem = new EffectType { Name = "AddItem" };
            var effectTypeGoToScene = new EffectType { Name = "GoToScene" };

            var outcome = new Outcome
            {
                Label = "PickupSuccess",
                Effects = new List<Effect>
                {
                    new Effect
                    {
                        EffectType = effectTypeAddItem,
                        Value = 1
                    },
                    new Effect
                    {
                        EffectType = effectTypeGoToScene,
                        Value = 1
                    }
                },
                Conditions = new List<Condition>()
            };

            return new Choice
            {
                Description = "Ramasser l'épée rouillée",
                Scene = scene,
                IsRepeatable = false,
                Outcomes = new List<Outcome> { outcome }
            };
        }

        private static Choice CreateMountainChoice(Scene scene)
        {
            var effectTypeGoToScene = new EffectType { Name = "GoToScene" };
            var effectTypeLoseHP = new EffectType { Name = "LoseHP" };
            var effectTypeHeal = new EffectType { Name = "Heal" };

            var conditionTypeStrength = new ConditionType { Name = "TestStrengthAbove" };

            var condition = new Condition
            {
                ConditionType = conditionTypeStrength,
                Value = 4
            };

            var successOutcome = new Outcome
            {
                Label = "Success",
                Conditions = new List<Condition> { condition },
                Effects = new List<Effect>
                {
                    new Effect
                    {
                        EffectType = effectTypeHeal,
                        Value = 10
                    },
                    new Effect
                    {
                        EffectType = effectTypeGoToScene,
                        Value = 1
                    }
                }
            };

            var failureOutcome = new Outcome
            {
                Label = "Failure",
                Conditions = new List<Condition>(),
                Effects = new List<Effect>
                {
                    new Effect
                    {
                        EffectType = effectTypeLoseHP,
                        Value = 5
                    },
                    new Effect
                    {
                        EffectType = effectTypeGoToScene,
                        Value = 1
                    }
                }
            };

            return new Choice
            {
                Description = "Partir vers la montagne",
                Scene = scene,
                IsRepeatable = true,
                Outcomes = new List<Outcome> { successOutcome, failureOutcome }
            };
        }
    }
}
