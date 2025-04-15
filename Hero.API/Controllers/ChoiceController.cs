using Hero.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hero.API.Controllers
{
    public class ChoiceController : ControllerBase
    {
        private readonly PlayerService _playerService;
        private readonly ChoiceService _choiceService;

        public ChoiceController(PlayerService playerService, ChoiceService choiceService)
        {
            _playerService = playerService;
            _choiceService = choiceService;
        }
        /*

        [HttpPost("api/choices/{choiceId}")]
        public async Task<IActionResult> PostChoice(int choiceId, [FromBody] ChoiceRequestDto request)
        {
            var player = await _playerService.GetPlayerByIdAsync(request.UserId);
            var choice = await _choiceService.GetByIdAsync(choiceId);

            if (!choice.IsAvailableTo(player))
                return BadRequest("Choice not allowed");

            await _choiceService.ApplyChoiceEffectsAsync(player, choice);

            return Ok(new ChoiceResultDto
            {
                NextSceneId = choice.NextSceneId
            });
        }
        */
    }
}
