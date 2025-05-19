using Board_Game_Ledger.DTOs.GameSession;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Interfaces.IServices
{
    public interface IGameSessionService
    {
        Task<GameSession> CreateGameSessionAsync(CreateGameSessionRequestDto dto, string appUserId);
        Task<GameSessionDto?> GetByIdAsync(int id);
        Task<List<GameSessionDto>> GetAllAsync();
        Task<GameSession> DeleteAsync(int id);
        Task<GameSession?> UpdateAsync(int id, UpdateGameSessionRequestDto gameSessionDto);
    }
}
