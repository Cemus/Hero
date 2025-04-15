using Hero.API.Builders;
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
                Choices = []
            };
        }

        public static void AddBasicChoices(Scene scene)
        {
            scene.Choices.Add(CreateItemPickupChoice(scene));
            scene.Choices.Add(CreateMountainChoice(scene));
        }

        private static Choice CreateItemPickupChoice(Scene scene)
        {
            Outcome outcome = new OutcomeBuilder()
                .SetLabel("PickUpRustedSword")
                .AddEffect(EffectFactory.AddItem(1))
                .Build();

            return new Choice
            {
                Description = "Ramasser l'épée rouillée",
                Scene = scene,
                IsRepeatable = false,
                Outcomes = [outcome]
            };
        }

        private static Choice CreateMountainChoice(Scene scene)
        {
            EffectType effectTypeGoToScene = new() { Name = "GoToScene" };
            EffectType effectTypeLoseHP = new() { Name = "LoseHP" };
            EffectType effectTypeHeal = new() { Name = "Heal" };

            ConditionType conditionTypeStrength = new() { Name = "TestStrengthAbove" };

            Condition condition = new()
            {
                ConditionType = conditionTypeStrength,
                Value = 4
            };

            var successOutcome = new Outcome
            {
                Label = "Success",
                FeedBack = "Vous arpentez la montagne !",
                Conditions = [condition],
                Effects =
                {
                    new()
                    {
                        EffectType = effectTypeHeal,
                        Value = 10
                    },
                    new()
                    {
                        EffectType = effectTypeGoToScene,
                        Value = 1
                    }
                }
            };

            var failureOutcome = new Outcome
            {
                Label = "Failure",
                FeedBack = "Vous faîtes une crise d'asthme en essayant de gravir cet Everest...",
                Conditions = [],
                Effects =
                [
                    new() {
                        EffectType = effectTypeLoseHP,
                        Value = 5
                    },
                    new() {
                        EffectType = effectTypeGoToScene,
                        Value = 1
                    }
                ]
            };

            return new Choice
            {
                Description = "Partir vers la montagne",
                Scene = scene,
                IsRepeatable = true,
                Outcomes = [successOutcome, failureOutcome]
            };
        }
    }
}
