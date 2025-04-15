using Hero.API.Data;
using Hero.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hero.API.Repositories
{
    public class PlayerRepository
    {
        private readonly HeroDbContext _context;

        public PlayerRepository(HeroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _context.Players.Include(p => p.Stats).Include(p => p.Job).ToListAsync();
        }

        public async Task<Player?> GetByIdAsync(int id)
        {
            return await _context.Players.Include(p => p.Stats).Include(p => p.Job).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Player player)
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync(Player player)
        {
            var existingPlayer = await _context.Players
                                               .FirstOrDefaultAsync(p => p.Id == player.Id);

            if (existingPlayer == null)
            {
                throw new Exception("Player not found");
            }

            existingPlayer.Name = player.Name;
            existingPlayer.JobId = player.JobId;
            existingPlayer.StatsId = player.StatsId;

            await _context.SaveChangesAsync();
        }
    }
}
