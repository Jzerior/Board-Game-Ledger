using Board_Game_Ledger.Data;
using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Models;
using Microsoft.EntityFrameworkCore;

namespace Board_Game_Ledger.Repositories
{
    public class BoardGameRepository : IBoardGameRepository
    {
        private readonly ApplicationDBContext _context;
        public BoardGameRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<BoardGame> CreateAsync(BoardGame boardGame)
        {
            await _context.BoardGames.AddAsync(boardGame);
            await _context.SaveChangesAsync();
            return boardGame;
        }

        public async Task<BoardGame?> DeleteAsync(int id)
        {
            var boardGame = await _context.BoardGames.FirstOrDefaultAsync(bg => bg.Id == id);
            if (boardGame == null)
            {
                return null;
            }
            _context.BoardGames.Remove(boardGame);
            await _context.SaveChangesAsync();
            return boardGame;
        }

        public Task<List<BoardGame>> GetAllAsync()
        {
            return await _context.BoardGames.ToListAsync();
        }

        public async Task<BoardGame?> GetByIdAsync(int id)
        {
            return await _context.BoardGames.FirstOrDefaultAsync(bg => bg.Id == id);
        }

        public async Task<BoardGame?> GetByNameAsync(string name)
        {
            return await _context.BoardGames.FirstOrDefaultAsync(bg => bg.Name == name);
        }
    }
}
