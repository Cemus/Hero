using Hero.API.Services;
using Hero.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Hero.API.Controllers
{
    // A FIX
    [Route("api/jobs/")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly JobService _jobService;

        public JobController(JobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            JobDto? job = await _jobService.GetJobByIdAsync(id);

            return job != null ? Ok(job) : NotFound();
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<JobDto>? jobs = await _jobService.GetAllJobsAsync();

            return Ok(jobs);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] JobNameDto jobName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                JobDto job = await _jobService.CreateJobAsync(jobName.Name);
                return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{jobName}")]
        public async Task<IActionResult> Delete([FromBody] string jobName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                JobDto job = await _jobService.GetJobByNameAsync(jobName);
                await _jobService.DeleteJobAsync(job);
                return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

