using System.Numerics;
using Board_Game_Ledger.Data;
using Board_Game_Ledger.DTOs.Player;
using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Models;
using Microsoft.EntityFrameworkCore;

namespace Board_Game_Ledger.Repositories
{
    public class PlayerRepository : IPlayerRepository
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

        public async Task<List<Player>> CreateRangeAsync(List<Player> players)
        {
            await _context.Players.AddRangeAsync(players);
            await _context.SaveChangesAsync();
            return players;
        }

        public async Task<Player?> DeleteAsync(int id, string userId)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);
            if (player == null)
            {
                return null;
            }
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<List<Player>> GetAllAsync(string userId)
        {
            return await _context.Players
                .Where(p => p.AppUserId == userId)
                .ToListAsync();
        }

        public async Task<Player?> GetByIdAsync(int id, string userId)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.Id == id && p.AppUserId == userId);
        }

        public async Task<Player?> GetByNameAsync(string name, string userId)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.Name == name && p.AppUserId == userId);
        }

        public async Task<Player?> UpdateAsync(int id,UpdatePlayerRequestDto playerDto, string userId)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == id && p.AppUserId == userId);
            if (player == null)
            {
                return null;
            }
            player.Name = playerDto.Name;
            await _context.SaveChangesAsync();
            return player;
        }
    }
}
