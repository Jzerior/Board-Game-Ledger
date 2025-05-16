using Board_Game_Ledger.DTOs.GameSession;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Interfaces.IServices
{
    public interface IGameSessionService
    {
        Task<GameSession> CreateGameSessionAsync(CreateGameSessionRequestDto dto);
        Task<GameSessionDto?> GetByIdAsync(int id);
        Task<List<GameSessionDto>> GetAllAsync();
    }
}
