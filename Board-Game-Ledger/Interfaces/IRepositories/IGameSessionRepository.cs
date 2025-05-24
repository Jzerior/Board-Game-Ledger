using Board_Game_Ledger.DTOs.GameSession;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Interfaces.IRepositories
{
    public interface IGameSessionRepository
    {
        Task<List<GameSession>> GetAllAsync(string userId);
        Task<GameSession?> GetByIdAsync(int id, string userId);
        Task<GameSession?> CreateAsync(GameSession gameSession);
        Task<GameSession?> UpdateAsync(int id, GameSession gameSession, string userId);
        Task<GameSession?> DeleteAsync(int id, string userId);
        Task<List<GameSession>> GetByBoardGameIdAsync(int boardGameId, string userId);
        Task<List<GameSession>> GetByPlayerIdAsync(int playerId, string userId);
    }
}
