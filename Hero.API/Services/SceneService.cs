using Hero.API.Repositories;
using Hero.Shared.Dtos;
using Hero.Shared.Models;

namespace Hero.API.Services
{
    public class SceneService
    {
        private readonly SceneRepository _sceneRepository;

        public SceneService(SceneRepository sceneRepository)
        {
            _sceneRepository = sceneRepository;
        }

        public SceneDto BuildScene(Scene scene)
        {
            var sceneDto = new SceneDto
            {
                Id = scene.Id,
                Name = scene.Name,
                Description = scene.Description,
                Choices = new List<ChoiceDto>()
            };

            foreach (var choice in scene.Choices)
            {
                var choiceDto = new ChoiceDto
                {
                    Id = choice.Id,
                    Description = choice.Description,
                    Outcomes = new List<Outcome>()
                };

                foreach (var outcome in choice.Outcomes)
                {
                    var outcomeDto = new OutcomeDto
                    {
                        Label = outcome.Label,
                        Conditions = new List<ConditionDto>(),
                        Effects = new List<EffectDto>(),
                    };

                    foreach (var condition in outcome.Conditions)
                    {
                        var conditionDto = new ConditionDto
                        {
                            ConditionType = new ConditionTypeDto
                            {
                                Name = condition.ConditionType.Name
                            }
                        };
                        outcomeDto.Conditions.Add(conditionDto);
                    }
                    foreach (var effect in outcome.Effects)
                    {
                        var effectDto = new EffectDto
                        {
                            EffectType = new EffectTypeDto
                            {
                                Name = effect.EffectType.Name
                            }
                        };
                        outcomeDto.Effects.Add(effectDto);
                    }
                }

                sceneDto.Choices.Add(choiceDto);
            }
            return sceneDto;
        }

        public async Task<SceneDto> GetSceneByIdAsync(int id)
        {
            Scene? scene = await _sceneRepository.GetByIdAsync(id);

            if (scene == null)
            {
                throw new Exception("Scene not found");
            }

            return BuildScene(scene);
        }

        public async Task<List<SceneDto>> GetAllSceneAsync()
        {
            List<Scene> scenes = await _sceneRepository.GetAllAsync();

            List<SceneDto> scenesDto = new List<SceneDto>();

            foreach (var scene in scenes)
            {
                SceneDto newScene = BuildScene(scene);
                scenesDto.Add(newScene);
            }

            return scenesDto;
        }
    }
}
