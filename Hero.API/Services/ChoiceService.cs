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




        public async Task<ChoiceResultDto> ApplyChoiceAsync(PlayerDto player, ChoiceDto choice)
        {
            if (choice.IsRepeatable || await _choiceRepository.IsChoicePresentInHistory(player.Id, choice.Id))
            {

                Choice? currentChoice = await _choiceRepository.GetByIdAsync(choice.Id);
                Player? currentPlayer = await _playerRepository.GetByIdAsync(player.Id);

                if (currentChoice == null || currentPlayer == null)
                {
                    throw new Exception("Player or Choice not found during the record in history");
                }

                await _choiceRepository.AddChoiceToHistory(currentChoice, currentPlayer);

                await TestOutcomes(choice.Outcomes, player);

                return new ChoiceResultDto() { FeedBack = "Nothing..." };
            }
            throw new Exception("Invalid choice");
        }

        public async Task<ChoiceResultDto?> TestOutcomes(ICollection<OutcomeDto> outcomes, PlayerDto player)
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
                    return new ChoiceResultDto() { FeedBack = outcome.FeedBack };
                }
            }
            return new ChoiceResultDto() { FeedBack = "Aucun effet n'a pu être appliqué." };

        }

        public bool TestCondition(ConditionDto condition, PlayerDto player)
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

        public async Task ApplyEffect(EffectDto effect, PlayerDto player)
        {
            switch (effect.EffectType.Name)
            {
                case "AddItem":
                    await _playerRepository.AddItemToInventoryAsync(player.Id, effect.Value!.Value);
                    break;

                case "LoseHP":
                    await _playerRepository.LoseHPAsync(player.Id, effect.Value!.Value);
                    break;

                case "Heal":
                    await _playerRepository.HealAsync(player.Id, effect.Value!.Value);
                    break;

                case "GoToScene":
                    await _playerRepository.SetCurrentSceneAsync(player.Id, effect.Value!.Value);
                    break;

                default:
                    throw new Exception($"Unknown effect : {effect.EffectType.Name}");
            }
        }
    }
}
