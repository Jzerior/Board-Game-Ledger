using Board_Game_Ledger.Data;
using Board_Game_Ledger.DTOs.GameSession;
using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Repositories
{
    public class GameSessionRepository : IGameSessionRepository
    {
        private readonly ApplicationDBContext _context;
        public GameSessionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<GameSession?> CreateAsync(GameSession gameSession)
        {
            throw new NotImplementedException();
        }

        public Task<GameSession?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GameSession>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<GameSession>> GetByBoardGameIdAsync(int boardGameId)
        {
            throw new NotImplementedException();
        }

        public Task<GameSession?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
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
