using Hero.API.Services;
using Hero.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Hero.API.Controllers
{
    [Route("api/scenes/")]
    [ApiController]
    public class SceneController : ControllerBase
    {
        private readonly SceneService _sceneService;

        public SceneController(SceneService sceneService)
        {
            _sceneService = sceneService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            SceneDto? scene = await _sceneService.GetSceneByIdAsync(id);

            return scene != null ? Ok(scene) : NotFound();
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            List<SceneDto> scenes = await _sceneService.GetAllSceneAsync();

            return scenes.Count > 0 ? Ok(scenes) : NotFound();
        }
    }
}
