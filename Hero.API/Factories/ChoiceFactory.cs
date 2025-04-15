using Hero.API.Builders;
using Hero.Shared.Models;

namespace Hero.API.Factories
{
    public static class ChoiceFactory
    {
        public static Choice PickItem(Scene scene, int itemId)
        {
            Choice choice = new() { Description = "", IsRepeatable = true, Outcomes = [] };
            Outcome outcome = new OutcomeBuilder()
            .SetLabel($"PickUpItem{itemId}")
            .SetFeedBack($"Vous ramassez #{itemId}") // Essayer de choper l'item depuis la db
            .AddEffect(EffectFactory.AddItem(itemId))
            .Build();

            choice.Scene = scene;
            choice.SceneId = scene.Id;
            choice.IsRepeatable = false;
            choice.Outcomes.Add(outcome);

            return choice;
        }

        public static Choice GoToScene(Scene scene, int sceneId)
        {
            Choice choice = new() { Description = "", IsRepeatable = true, Outcomes = [] };
            Outcome outcome = new OutcomeBuilder()
            .SetLabel($"GoToScene{sceneId}")
            .AddEffect(EffectFactory.GoToScene(sceneId))
            .Build();

            choice.Scene = scene;
            choice.SceneId = scene.Id;
            choice.Outcomes.Add(outcome);

            return choice;
        }
    }
}
