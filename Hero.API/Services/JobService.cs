using Hero.API.Repositories;
using Hero.Shared.Dtos;
using Hero.Shared.Models;

namespace Hero.API.Services
{
    public class JobService
    {
        private readonly JobRepository _jobRepository;

        public JobService(JobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<JobDto>> GetAllJobsAsync()
        {
            List<Job> jobs = await _jobRepository.GetAllAsync();

            return jobs.Select(p => new JobDto
            {
                Id = p.Id,
                Name = p.Name
            });
        }

        public async Task<JobDto> GetJobByIdAsync(int id)
        {
            Job? job = await _jobRepository.GetByIdAsync(id);

            if (job == null)
            {
                throw new Exception("Job not found");
            }

            return new JobDto
            {
                Id = job.Id,
                Name = job.Name,
            };
        }

        public async Task<JobDto> GetJobByNameAsync(string jobName)
        {
            Job? job = await _jobRepository.GetByNameAsync(jobName);

            if (job == null)
            {
                throw new Exception("Job not found");
            }

            return new JobDto
            {
                Id = job.Id,
                Name = job.Name,
            };
        }

        public async Task DeleteJobAsync(JobDto job)
        {
            Job? existantJob = await _jobRepository.GetByNameAsync(job.Name);

            if (existantJob == null)
            {
                throw new Exception("Job not found");
            }

            await _jobRepository.DeleteAsync(job.Id);
        }



        public async Task<JobDto> CreateJobAsync(string jobName)
        {
            Job? existantJob = await _jobRepository.GetByNameAsync(jobName);

            if (existantJob != null)
            {
                throw new Exception("Job already exists");
            }

            Job newJob = new(jobName);

            await _jobRepository.AddAsync(newJob);

            return new JobDto
            {
                Id = newJob.Id,
                Name = newJob.Name,
            };
        }

    }
}
