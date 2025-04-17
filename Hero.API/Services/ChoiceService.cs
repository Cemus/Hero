using System.Text.Json;
using Hero.API.Repositories;
using Hero.Shared.Dtos;
using Hero.Shared.Models;

namespace Hero.API.Services
{
    public class ChoiceService
    {
        private readonly ChoiceRepository _choiceRepository;
        private readonly PlayerRepository _playerRepository;
        public ChoiceService(ChoiceRepository choiceRepository, PlayerRepository playerRepository)
        {
            _choiceRepository = choiceRepository;
            _playerRepository = playerRepository;
        }

        public async Task<ChoiceDto> GetChoiceByIdAsync(int choiceId)
        {
            Choice? choice = await _choiceRepository.GetByIdAsync(choiceId);

            if (choice == null)
            {
                throw new Exception("Choice not found");
            }

            ChoiceDto choiceDto = new()
            {
                Description = choice.Description,
                IsRepeatable = choice.IsRepeatable,
            };

            foreach (var outcome in choice.Outcomes)
            {
                OutcomeDto outcomeDto = new()
                {
                    FeedBack = outcome.FeedBack,
                    Label = outcome.Label,
                };
                foreach (var effect in outcome.Effects)
                {
                    EffectDto effectDto = new()
                    {
                        EffectType = new EffectTypeDto() { Name = effect.EffectType.Name },
                        Value = effect.Value
                    };
                    outcomeDto.Effects.Add(effectDto);
                }
                foreach (var condition in outcome.Conditions)
                {
                    ConditionDto conditionDto = new()
                    {
                        ConditionType = new ConditionTypeDto() { Name = condition.ConditionType.Name },
                        Value = condition.Value
                    };
                    outcomeDto.Conditions.Add(conditionDto);
                }

                choiceDto.Outcomes.Add(outcomeDto);
            }

            return choiceDto;
        }




        public async Task<ChoiceResultDto> ApplyChoiceAsync(int playerId, int choiceId)
        {
            Player? player = await _playerRepository.GetByIdAsync(playerId);
            Choice? choice = await _choiceRepository.GetByIdAsync(choiceId);

            if (player == null || choice == null)
            {
                throw new Exception("Player or Choice not found during the record in history");
            }

            if (choice.IsRepeatable || !(await _choiceRepository.IsChoicePresentInHistory(player.Id, choice.Id)))
            {

                await _choiceRepository.AddChoiceToHistory(choice, player);

                var feedBack = await TestOutcomes(choice.Outcomes, player);

                return new ChoiceResultDto() { FeedBack = feedBack };
            }
            throw new Exception("You can't repeat this choice");
        }

        public async Task<string> TestOutcomes(ICollection<Outcome> outcomes, Player player)
        {
            foreach (var outcome in outcomes)
            {
                bool conditionsValid = true;

                foreach (var condition in outcome.Conditions)
                {
                    conditionsValid = TestCondition(condition, player);
                }

                if (conditionsValid)
                {
                    foreach (var effect in outcome.Effects)
                    {
                        await ApplyEffect(effect, player);
                    }
                    Console.WriteLine(outcome);
                    Console.WriteLine(JsonSerializer.Serialize(outcome));
                    return outcome.FeedBack;
                }
            }
            return "Aucun effet n'a pu être appliqué.";
        }

        public bool TestCondition(Condition condition, Player player)
        {
            bool validCondition = true;

            switch (condition.ConditionType.Name)
            {
                case "TestStrengthAbove":
                    if (!(player.Stats.Strength > condition.Value))
                    {
                        validCondition = false;
                    }
                    break;

                case "TestKnowledgeAbove":
                    if (!(player.Stats.Knowledge > condition.Value))
                    {
                        validCondition = false;
                    }
                    break;

                case "TestDexterityAbove":
                    if (!(player.Stats.Dexterity > condition.Value))
                    {
                        validCondition = false;
                    }
                    break;

                case "TestVitalityAbove":
                    if (!(player.Stats.Vitality > condition.Value))
                    {
                        validCondition = false;
                    }
                    break;

                case "TestDefenseAbove":
                    if (!(player.Stats.Defense > condition.Value))
                    {
                        validCondition = false;
                    }
                    break;

                case "TestCharismaAbove":
                    if (!(player.Stats.Charisma > condition.Value))
                    {
                        validCondition = false;
                    }
                    break;

                default:
                    throw new Exception($"Unknown condition : {condition.ConditionType.Name}");
            }

            return validCondition;
        }

        public async Task ApplyEffect(Effect effect, Player player)
        {
            switch (effect.EffectType.Name)
            {
                case "AddItem":
                    await _playerRepository.AddItemToInventoryAsync(player, effect.Value!.Value);
                    break;

                case "LoseHP":
                    await _playerRepository.LoseHPAsync(player, effect.Value!.Value);
                    break;

                case "Heal":
                    await _playerRepository.HealAsync(player, effect.Value!.Value);
                    break;

                case "GoToScene":
                    await _playerRepository.SetCurrentSceneAsync(player, effect.Value!.Value);
                    break;

                default:
                    throw new Exception($"Unknown effect : {effect.EffectType.Name}");
            }
        }
    }
}
