using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Interfaces.IRepositories
{
    public interface IPlayerRepostiory
    {
        Task<List<Player>> GetAllAsync();
        Task<Player?> GetByIdAsync(int id);
        Task<Player?> GetByNameAsync(string name);
        Task<Player> CreateAsync(BoardGame boardGame);
        //Task<Player?> UpdateAsync(int id,BoardGame boardGame);
        Task<Player?> DeleteAsync(int id);
    }
}
