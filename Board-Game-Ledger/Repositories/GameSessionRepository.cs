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

        public async Task<GameSession?> DeleteAsync(int id, string userId)
        {
            var session = await _context.GameSessions.FirstOrDefaultAsync(gs => gs.Id == id && gs.AppUserId == userId);
            if(session == null)
            {
                return null;
            }
            _context.GameSessions.Remove(session);
            await _context.SaveChangesAsync();
            return session;
        }

        public async Task<List<GameSession>> GetAllAsync(string userId)
        {
            return await _context.GameSessions
                .Where(gs => gs.AppUserId == userId)
                .Include(gs => gs.BoardGame)
                .Include(gs => gs.GameSessionPlayers)
                .ThenInclude(gsp => gsp.Player)
                .ToListAsync();
        }

        public Task<List<GameSession>> GetByBoardGameIdAsync(int boardGameId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<GameSession?> GetByIdAsync(int id, string userId)
        {
            return await _context.GameSessions
                .Include(gs => gs.BoardGame)
                .Include(gs => gs.GameSessionPlayers)
                .ThenInclude(gsp => gsp.Player)
                .FirstOrDefaultAsync(gs => gs.Id == id && gs.AppUserId == userId);
        }

        public Task<List<GameSession>> GetByPlayerIdAsync(int playerId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<GameSession?> UpdateAsync(int id, GameSession gameSession, string userId)
        {
            var session = await _context.GameSessions.FirstOrDefaultAsync(gs => gs.Id == id && gs.AppUserId == userId);
            if (session == null)
            {
                return null;
            }
            session.BoardGameId = gameSession.BoardGameId;
            session.PlayedAt = gameSession.PlayedAt;
            session.Duration = gameSession.Duration;
            //session.PlayerCount = gameSession.PlayerCount;
            await _context.SaveChangesAsync();
            return session;
        }
    }
}
