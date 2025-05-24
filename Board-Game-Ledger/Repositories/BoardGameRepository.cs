using Board_Game_Ledger.Data;
using Board_Game_Ledger.DTOs.BoardGame;
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

        public async Task<BoardGame?> DeleteAsync(int id, string userId)
        {
            var boardGame = await _context.BoardGames.FirstOrDefaultAsync(bg => bg.Id == id && bg.AppUserId == userId);
            if (boardGame == null)
            {
                return null;
            }
            _context.BoardGames.Remove(boardGame);
            await _context.SaveChangesAsync();
            return boardGame;
        }

        public async Task<List<BoardGame>> GetAllAsync(string userId)
        {
            return await _context.BoardGames
                .Where(bg => bg.AppUserId == userId)
         .ToListAsync();
        }

        public async Task<BoardGame?> GetByIdAsync(int id, string userId)
        {
            return await _context.BoardGames.FirstOrDefaultAsync(bg => bg.Id == id && bg.AppUserId == userId);
        }

        public async Task<BoardGame?> GetByNameAsync(string name, string userId)
        {
            return await _context.BoardGames.FirstOrDefaultAsync(bg => bg.Name == name && bg.AppUserId == userId);
        }

        public async Task<BoardGame?> UpdateAsync(int id, UpdateBoardGameRequestDto boardGameDto, string userId)
        {
            var boardGame = await _context.BoardGames.FirstOrDefaultAsync(bg => bg.Id == id && bg.AppUserId == userId);
            if (boardGame == null)
            {
                return null;
            }
            boardGame.Name = boardGameDto.Name;
            boardGame.Genre = boardGameDto.Genre;
            boardGame.MinPlayerCount = boardGameDto.MinPlayerCount;
            boardGame.MaxPlayerCount = boardGameDto.MaxPlayerCount;
            await _context.SaveChangesAsync();
            return boardGame;

        }
    }
}
