using Board_Game_Ledger.DTOs.GameSession;
using Board_Game_Ledger.DTOs.GameSessionPlayer;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Mappers
{
    public static class GameSessionMapper
    {
        public static GameSessionDto ToDto(this GameSession gameSession)
        {
            return new GameSessionDto
            {
                Id = gameSession.Id,
                BoardGameId = gameSession.BoardGameId,
                PlayedAt = gameSession.PlayedAt,
                Duration = gameSession.Duration,
                BoardGame = gameSession.BoardGame.toBGDto(),
                PlayerCount = gameSession.PlayerCount,
                Description = gameSession.Description,
                GameSessionPlayers = gameSession.GameSessionPlayers?
            .Select(p => new GameSessionPlayerDto
            {
                PlayerId = p.PlayerId,
                Place = p.Place,
                Player = p.Player.toPlayerDTO(),
                Score = p.Score
            }).ToList()
            };

        }
        public static GameSession toGameSessionFromCreateRequest(this CreateGameSessionRequestDto dto, string appUserId)
        {
            return new GameSession
            {
                BoardGameId = dto.BoardGameId,
                PlayedAt = dto.PlayedAt,
                Duration = dto.Duration,
                Description = dto.Description,
                AppUserId = appUserId,
                PlayerCount = dto.GameSessionPlayers.Count()
            };
        }
        public static GameSession toGameSessionFromUpdateRequest(this UpdateGameSessionRequestDto dto)
        {
            return new GameSession
            {
                BoardGameId = dto.BoardGameId,
                PlayedAt = dto.PlayedAt,
                Duration = dto.Duration,
                Description = dto.Description,
                //PlayerCount = dto.GameSessionPlayers.Count()
            };
        }
    }
}
