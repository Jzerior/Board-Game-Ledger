using Board_Game_Ledger.DTOs.GameSession;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Interfaces.IRepositories
{
    public interface IGameSessionRepository
    {
        Task<List<GameSession>> GetAllAsync();
        Task<GameSession?> GetByIdAsync(int id);
        Task<GameSession?> CreateAsync(GameSession gameSession);
        Task<GameSession?> UpdateAsync(int id, GameSession gameSession);
        Task<GameSession?> DeleteAsync(int id);
        Task<List<GameSession>> GetByBoardGameIdAsync(int boardGameId);
        Task<List<GameSession>> GetByPlayerIdAsync(int playerId);
    }
}
