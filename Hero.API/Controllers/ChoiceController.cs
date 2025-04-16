using Hero.API.Services;
using Hero.Shared.Dtos;
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


        [HttpPost("api/choices/")]
        public async Task<IActionResult> PostChoice([FromBody] ChoiceRequestDto request)
        {
            try
            {
                PlayerDto player = await _playerService.GetPlayerByIdAsync(request.CharacterId);
                ChoiceDto choice = await _choiceService.GetChoiceByIdAsync(request.ChoiceId);


                ChoiceResultDto choiceResult = await _choiceService.ApplyChoiceAsync(player, choice);

                return Ok(choiceResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}
