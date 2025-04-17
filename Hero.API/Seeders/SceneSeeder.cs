using Hero.API.Data;
using Hero.API.Factories;
using Hero.Shared.Models;

namespace Hero.API.Seeders
{
    public static class SceneSeeder
    {
        public static void SeedScenes(HeroDbContext context)
        {
            if (!context.Scenes.Any(s => s.Name == "Début"))
            {
                var scene = SceneFactory.CreateScene("Début", "Tu te réveilles dans une clairière, blablabla.");

                SceneFactory.AddBasicChoices(scene);

                foreach (var choice in scene.Choices)
                {
                    foreach (var outcome in choice.Outcomes ?? Enumerable.Empty<Outcome>())
                    {
                        foreach (var effect in outcome.Effects ?? Enumerable.Empty<Effect>())
                        {
                            if (effect.EffectType?.Name == "GoToScene" && effect.Value > 0)
                            {
                                var targetSceneId = effect.Value;

                                if (!context.Scenes.Any(s => s.Id == targetSceneId))
                                {
                                    context.Scenes.Add(new Scene
                                    {
                                        Name = $"scene_{targetSceneId}",
                                        Description = $"[placeholder...] Scène #{targetSceneId}"
                                    });
                                }
                            }
                        }
                    }
                }

                context.Scenes.Add(scene);
                context.SaveChanges();
            }
        }
    }
}
