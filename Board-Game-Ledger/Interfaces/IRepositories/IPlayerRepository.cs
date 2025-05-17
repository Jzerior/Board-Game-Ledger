using Board_Game_Ledger.DTOs.Player;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Interfaces.IRepositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllAsync();
        Task<Player?> GetByIdAsync(int id);
        Task<Player?> GetByNameAsync(string name);
        Task<Player> CreateAsync(Player player);
        Task<Player?> UpdateAsync(int id,CreatePlayerRequestDto playerDto);
        Task<Player?> DeleteAsync(int id);
        Task<List<Player>> CreateRangeAsync(List<Player> players);
    }
}
