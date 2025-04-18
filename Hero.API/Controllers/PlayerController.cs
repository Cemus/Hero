using FluentValidation;
using Hero.API.Services;
using Hero.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Hero.API.Controllers
{
    [Route("api/players/")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;
        private readonly IValidator<CreatePlayerDto> _validator;

        public PlayerController(PlayerService playerService, IValidator<CreatePlayerDto> validator)
        {
            _playerService = playerService;
            _validator = validator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                PlayerDto? player = await _playerService.GetPlayerByIdAsync(id);

                return player != null ? Ok(player) : NotFound();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<PlayerDto> players = await _playerService.GetAllPlayersAsync();

                return Ok(players);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CreatePlayerDto playerInfos)
        {
            var validationResult = await _validator.ValidateAsync(playerInfos);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            try
            {
                PlayerDto player = await _playerService.CreatePlayerAsync(playerInfos);
                return CreatedAtAction(nameof(GetById), new { id = player.Id }, player);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _playerService.DeletePlayerAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
