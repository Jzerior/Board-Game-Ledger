using Board_Game_Ledger.DTOs.GameSessionPlayer;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Interfaces.IRepositories
{
    public interface IGameSessionPlayerRepository
    {
        Task<List<GameSessionPlayer>> GetAllAsync();
        Task<GameSessionPlayer?> GetByIdAsync(int gameSessionId, int playerId);
        Task<GameSessionPlayer?> CreateAsync(GameSessionPlayer gameSessionPlayer);
        Task<GameSessionPlayer?> UpdateAsync(int gameSessionId, int playerId, GameSessionPlayer gameSessionPlayer);
        Task<GameSessionPlayer?> DeleteAsync(int gameSessionId, int playerId);
        Task<List<GameSessionPlayer>> GetByGameSessionIdAsync(int gameSessionId);
        Task<List<GameSessionPlayer>> GetByPlayerIdAsync(int playerId);
    }
}
