using Board_Game_Ledger.DTOs.BoardGame;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Mappers
{
    public static class BoardGameMapper
    {
        public static BoardGame toBoardGameFromCreateDTO(this CreateBoardGameRequestDto boardGameDTO)
        {
            return new BoardGame
            {
                Name = boardGameDTO.Name,
                Genre = boardGameDTO.Genre,
                MinPlayerCount = boardGameDTO.MinPlayerCount,
                MaxPlayerCount = boardGameDTO.MaxPlayerCount
            };
        }
    }
}
