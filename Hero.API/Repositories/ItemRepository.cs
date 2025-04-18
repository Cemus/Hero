using Hero.API.Data;
using Hero.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hero.API.Repositories
{
    public class ItemRepository
    {
        private readonly HeroDbContext _context;
        public ItemRepository(HeroDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _context.Items
                .Include(i => i.Stats)
                .ToListAsync();
        }
    }
}
