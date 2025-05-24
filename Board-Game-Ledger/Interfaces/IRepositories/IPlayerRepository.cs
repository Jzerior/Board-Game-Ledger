using Board_Game_Ledger.DTOs.Player;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Interfaces.IRepositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllAsync(string userId);
        Task<Player?> GetByIdAsync(int id, string userId);
        Task<Player?> GetByNameAsync(string name, string userId);
        Task<Player> CreateAsync(Player player);
        Task<Player?> UpdateAsync(int id,UpdatePlayerRequestDto playerDto, string userId);
        Task<Player?> DeleteAsync(int id, string userId);
        Task<List<Player>> CreateRangeAsync(List<Player> players);
    }
}
