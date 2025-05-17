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
    }
}
