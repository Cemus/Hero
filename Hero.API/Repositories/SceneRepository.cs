using Hero.API.Data;
using Hero.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hero.API.Repositories
{
    public class SceneRepository
    {
        private readonly HeroDbContext _context;

        public SceneRepository(HeroDbContext context)
        {
            _context = context;
        }

        private IQueryable<Scene> IncludeAll(IQueryable<Scene> query)
        {
            return query
                .Include(s => s.Choices)
                    .ThenInclude(c => c.Outcomes)
                        .ThenInclude(o => o.Conditions)
                            .ThenInclude(c => c.ConditionType)
                .Include(s => s.Choices)
                   .ThenInclude(c => c.Outcomes)
                            .ThenInclude(o => o.Effects)
                                .ThenInclude(e => e.EffectType);
        }

        public async Task<Scene?> GetByIdAsync(int id)
        {
            return await IncludeAll(_context.Scenes)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Scene?> GetByNameAsync(string name)
        {
            return await IncludeAll(_context.Scenes)
                .FirstOrDefaultAsync(s => s.Name == name);

        }

        public async Task<List<Scene>> GetAllAsync()
        {
            return await IncludeAll(_context.Scenes)
                .ToListAsync();
        }

        public async Task AddAsync(Scene scene)
        {
            await _context.Scenes.AddAsync(scene);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Scene? scene = await _context.Scenes.FindAsync(id);

            if (scene != null)
            {
                _context.Scenes.Remove(scene);
                await _context.SaveChangesAsync();
            }
        }
    }
}
