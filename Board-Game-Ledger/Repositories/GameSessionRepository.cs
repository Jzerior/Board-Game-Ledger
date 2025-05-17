using Board_Game_Ledger.Data;
using Board_Game_Ledger.DTOs.GameSession;
using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Models;
using Microsoft.EntityFrameworkCore;

namespace Board_Game_Ledger.Repositories
{
    public class GameSessionRepository : IGameSessionRepository
    {
        private readonly ApplicationDBContext _context;
        public GameSessionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<GameSession?> CreateAsync(GameSession gameSession)
        {
            await _context.GameSessions.AddAsync(gameSession);
            await _context.SaveChangesAsync();
            return gameSession; 
        }

        public async Task<GameSession?> DeleteAsync(int id)
        {
            var session = await _context.GameSessions.FirstOrDefaultAsync(gs => gs.Id == id);
            if(session == null)
            {
                return null;
            }
            _context.GameSessions.Remove(session);
            await _context.SaveChangesAsync();
            return session;
        }

        public async Task<List<GameSession>> GetAllAsync()
        {
            return await _context.GameSessions
                .Include(gs => gs.BoardGame)
                .Include(gs => gs.GameSessionPlayers)
                .ThenInclude(gsp => gsp.Player)
                .ToListAsync();
        }

        public Task<List<GameSession>> GetByBoardGameIdAsync(int boardGameId)
        {
            throw new NotImplementedException();
        }

        public async Task<GameSession?> GetByIdAsync(int id)
        {
            return await _context.GameSessions
                .Include(gs => gs.BoardGame)
                .Include(gs => gs.GameSessionPlayers)
                .ThenInclude(gsp => gsp.Player)
                .FirstOrDefaultAsync(gs => gs.Id == id);
        }

        public Task<List<GameSession>> GetByPlayerIdAsync(int playerId)
        {
            throw new NotImplementedException();
        }

        public Task<GameSession?> UpdateAsync(int id, GameSession gameSession)
        {
            throw new NotImplementedException();
        }
    }
}
