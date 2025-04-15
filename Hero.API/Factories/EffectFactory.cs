using Hero.Shared.Models;

namespace Hero.API.Factories
{
    public class EffectFactory
    {
        public static Effect AddItem(int itemId) =>
             new() { EffectType = new EffectType { Name = "AddItem" }, Value = itemId };

        public static Effect GoToScene(int sceneId) =>
            new() { EffectType = new EffectType { Name = "GoToScene" }, Value = sceneId };

        public static Effect Heal(int amount) =>
            new() { EffectType = new EffectType { Name = "Heal" }, Value = amount };

        public static Effect LoseHP(int amount) =>
            new() { EffectType = new EffectType { Name = "LoseHP" }, Value = amount };
    }
}
