using Board_Game_Ledger.DTOs.GameSessionPlayer;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Mappers
{
    public static class GameSessionPlayerMapper
    {
        /*
         * public static BoardGame toBoardGameFromCreateDTO(this CreateBoardGameRequestDto boardGameDTO)
        {
            return new BoardGame
            {
                Name = boardGameDTO.Name,
                Genre = boardGameDTO.Genre,
                MinPlayerCount = boardGameDTO.MinPlayerCount,
                MaxPlayerCount = boardGameDTO.MaxPlayerCount
            };
        }
         */
        public static GameSessionPlayer toGameSessionPlayerFromCreateDto(this CreateGameSessionPlayerRequestDto gameSessionPlayerDTO)
        {
            return new GameSessionPlayer
            {
                Score = gameSessionPlayerDTO.Score,
                Place = gameSessionPlayerDTO.Place
            };
        }
        public static GameSessionPlayerDto toDto(this GameSessionPlayer gameSessionPlayer)
        {
            return new GameSessionPlayerDto
            {
                PlayerId = gameSessionPlayer.PlayerId,
                GameSessionId = gameSessionPlayer.GameSessionId,
                Score = gameSessionPlayer.Score,
                Place = gameSessionPlayer.Place,
                Player = gameSessionPlayer.Player.toPlayerDTO()
            };
        }
    }
}
