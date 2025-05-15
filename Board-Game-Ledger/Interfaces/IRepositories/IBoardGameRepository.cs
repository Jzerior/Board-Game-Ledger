using Board_Game_Ledger.DTOs.BoardGame;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Interfaces.IRepositories
{
    public interface IBoardGameRepository
    {
        Task<List<BoardGame>> GetAllAsync();
        Task<BoardGame?> GetByIdAsync(int id);
        Task<BoardGame?> GetByNameAsync(string name);
        Task<BoardGame> CreateAsync(BoardGame boardGame);
        Task<BoardGame?> UpdateAsync(int id,CreateBoardGameRequestDto boardGameDto);
        Task<BoardGame?> DeleteAsync(int id);
    }
}
