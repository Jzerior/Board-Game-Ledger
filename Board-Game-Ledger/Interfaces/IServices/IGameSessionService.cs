using Board_Game_Ledger.DTOs.GameSession;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Interfaces.IServices
{
    public interface IGameSessionService
    {
        Task<GameSession> CreateGameSessionAsync(CreateGameSessionRequestDto dto, string userId);
        Task<GameSessionDto?> GetByIdAsync(int id, string userId);
        Task<List<GameSessionDto>> GetAllAsync(string userId);
        Task<GameSession> DeleteAsync(int id, string userId);
        Task<GameSession?> UpdateAsync(int id, UpdateGameSessionRequestDto gameSessionDto, string userId);
    }
}
