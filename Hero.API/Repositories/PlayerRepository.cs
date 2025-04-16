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
            return await _context.Players.Include(p => p.Stats).Include(p => p.Job).Include(p => p.Items).ToListAsync();
        }

        public async Task<Player?> GetByIdAsync(int id)
        {
            return await _context.Players.Include(p => p.Stats).Include(p => p.Job).Include(p => p.Items).SingleOrDefaultAsync(p => p.Id == id);
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
            var existingPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Id == player.Id);

            if (existingPlayer == null)
            {
                throw new Exception("Player not found");
            }

            existingPlayer.Name = player.Name;
            existingPlayer.JobId = player.JobId;
            existingPlayer.StatsId = player.StatsId;

            await _context.SaveChangesAsync();
        }

        // Effects

        public async Task AddItemToInventoryAsync(int playerId, int itemId)
        {
            var player = await GetByIdAsync(playerId);


            if (player == null)
                throw new Exception("Player not found");

            var item = await _context.Items.FindAsync(itemId);
            if (item == null)
                throw new Exception("Item not found");


            player.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task LoseHPAsync(int playerId, int value)
        {
            var player = await GetByIdAsync(playerId);

            if (player == null)
                throw new Exception("Player not found");


            player.Stats.Vitality = Math.Max(0, player.Stats.Vitality - value);
            await _context.SaveChangesAsync();
        }

        public async Task HealAsync(int playerId, int value)
        {
            var player = await GetByIdAsync(playerId);

            if (player == null)
                throw new Exception("Player not found");


            player.Stats.Vitality = Math.Min(player.Stats.Vitality + value, 10);
            await _context.SaveChangesAsync();
        }

        public async Task SetCurrentSceneAsync(int playerId, int value)
        {
            var player = await GetByIdAsync(playerId);

            if (player == null)
                throw new Exception("Player not found");


            player.SceneId = value;
            await _context.SaveChangesAsync();
        }
    }
}
