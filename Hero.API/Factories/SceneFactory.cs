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
            List<Condition> conditions = [];

            scene.Choices.Add(CreateItemPickupChoice(scene));
            scene.Choices.Add(CreateChangeLocationChoice(scene, conditions, 1));
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


        private static Choice CreateChangeLocationChoice(Scene scene, List<Condition> conditions, int newSceneId)
        {

            var successOutcome = new Outcome
            {
                Label = "Success",
                FeedBack = "",
                Conditions = conditions,
                Effects =
                {
                    EffectFactory.GoToScene(newSceneId),
                }
            };

            var failureOutcome = new Outcome
            {
                Label = "Failure",
                FeedBack = "Vous faîtes une crise d'asthme en essayant de gravir cet Everest...",
                Conditions = [],
                Effects =
                [
                    EffectFactory.LoseHP(5),
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
