using Hero.API.Data;
using Hero.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hero.API.Repositories
{
    public class JobRepository
    {
        private readonly HeroDbContext _context;

        public JobRepository(HeroDbContext context)
        {
            _context = context;
        }

        public async Task<Job?> GetByIdAsync(int id)
        {
            return await _context.Jobs
                .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<Job?> GetByNameAsync(string name)
        {
            return await _context.Jobs.FirstOrDefaultAsync(j => j.Name == name);

        }

        public async Task<List<Job>> GetAllAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task AddAsync(Job job)
        {
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Job? job = await _context.Jobs.FindAsync(id);

            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }
        }
    }
}
