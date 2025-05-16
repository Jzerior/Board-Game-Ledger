using Board_Game_Ledger.Data;
using Board_Game_Ledger.DTOs.GameSessionPlayer;
using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Models;
using Microsoft.EntityFrameworkCore;

namespace Board_Game_Ledger.Repositories
{
    public class GameSessionPlayerRepository : IGameSessionPlayerRepository
    {
        private readonly ApplicationDBContext _context;
        public GameSessionPlayerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<GameSessionPlayer?> CreateAsync(GameSessionPlayer gameSessionPlayer)
        {
            
            await _context.AddAsync(gameSessionPlayer);
            await _context.SaveChangesAsync();
            return gameSessionPlayer;
        }

        public Task<GameSessionPlayer?> DeleteAsync(int gameSessionId, int playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GameSessionPlayer>> GetAllAsync()
        {
            return await _context.GameSessionPlayers.ToListAsync();
        }

        public Task<List<GameSessionPlayer>> GetByGameSessionIdAsync(int gameSessionId)
        {
            throw new NotImplementedException();
        }

        public async Task<GameSessionPlayer?> GetByIdAsync(int gameSessionId, int playerId)
        {
            var gameSessionPlayer = await _context.GameSessionPlayers
                .FirstOrDefaultAsync(gsp => gsp.GameSessionId == gameSessionId && gsp.PlayerId == playerId);
            if (gameSessionPlayer == null)
            {
                return null;
            }
            return gameSessionPlayer;
        }

        public async Task<List<GameSessionPlayer>> GetByPlayerIdAsync(int playerId)
        {
            var gameSessionPlayer = await _context.GameSessionPlayers.Where(gsp => gsp.PlayerId == playerId).ToListAsync();
            if (gameSessionPlayer == null)
            {
                return null;
            }
            return gameSessionPlayer;
        }

        public Task<GameSessionPlayer?> UpdateAsync(int gameSessionId, int playerId, GameSessionPlayer gameSessionPlayer)
        {
            throw new NotImplementedException();
        }
    }
}
