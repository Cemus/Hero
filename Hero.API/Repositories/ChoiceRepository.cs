using Hero.API.Data;
using Hero.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hero.API.Repositories
{
    public class ChoiceRepository
    {
        private readonly HeroDbContext _context;
        public ChoiceRepository(HeroDbContext context)
        {
            _context = context;
        }

        public async Task<Choice?> GetByIdAsync(int id)
        {
            return await _context.Choices
                .Include(c => c.Outcomes)
                    .ThenInclude(o => o.Effects)
                        .ThenInclude(e => e.EffectType)
                 .Include(c => c.Outcomes)
                    .ThenInclude(o => o.Conditions)
                        .ThenInclude(cond => cond.ConditionType)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> IsChoicePresentInHistory(int playerId, int choiceId)
        {
            return await _context.PlayerChoicesHistories.AnyAsync(pc => pc.PlayerId == playerId && pc.ChoiceId == choiceId);
        }

        public async Task AddChoiceToHistory(Choice choice, Player player)
        {
            PlayerChoiceHistory choiceToHistory = new()
            {
                Choice = choice,
                Player = player,
            };

            _context.PlayerChoicesHistories.Add(choiceToHistory);
            await _context.SaveChangesAsync();
        }
    }
}
