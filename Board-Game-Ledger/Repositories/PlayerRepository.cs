using Board_Game_Ledger.Data;
using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Models;
using Microsoft.EntityFrameworkCore;

namespace Board_Game_Ledger.Repositories
{
    public class PlayerRepository : IPlayerRepostiory
    {
        private readonly ApplicationDBContext _context;
        public PlayerRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Player> CreateAsync(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player?> DeleteAsync(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(bg => bg.Id == id);
            if (player == null)
            {
                return null;
            }
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<List<Player>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player?> GetByIdAsync(int id)
        {
            return await _context.Players.FirstOrDefaultAsync(bg => bg.Id == id);
        }

        public async Task<Player?> GetByNameAsync(string name)
        {
            return await _context.Players.FirstOrDefaultAsync(bg => bg.Name == name);
        }
    }
}
