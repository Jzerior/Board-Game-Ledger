using Board_Game_Ledger.DTOs.BoardGame;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Interfaces.IRepositories
{
    public interface IBoardGameRepository
    {
        Task<List<BoardGame>> GetAllAsync(string userId);
        Task<BoardGame?> GetByIdAsync(int id, string userId);
        Task<BoardGame?> GetByNameAsync(string name, string userId);
        Task<BoardGame> CreateAsync(BoardGame boardGame);
        Task<BoardGame?> UpdateAsync(int id,UpdateBoardGameRequestDto boardGameDto, string userId);
        Task<BoardGame?> DeleteAsync(int id, string userId);
    }
}
