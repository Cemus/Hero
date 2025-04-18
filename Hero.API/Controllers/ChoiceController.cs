using Hero.API.Services;
using Hero.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Hero.API.Controllers
{
    [ApiController]
    [Route("api/choices/")]

    public class ChoiceController : ControllerBase
    {
        private readonly ChoiceService _choiceService;

        public ChoiceController(ChoiceService choiceService)
        {
            _choiceService = choiceService;
        }


        [HttpPost("")]
        public async Task<IActionResult> PostChoice([FromBody] ChoiceRequestDto request)
        {
            try
            {
                ChoiceResultDto choiceResult = await _choiceService.ApplyChoiceAsync(request.PlayerId, request.ChoiceId);

                return Ok(choiceResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }


        }

    }
}
