using Board_Game_Ledger.DTOs.BoardGame;
using Board_Game_Ledger.DTOs.GameSessionPlayer;

namespace Board_Game_Ledger.DTOs.GameSession
{
    public class GameSessionDto
    {
        public int Id { get; set; }
        public int BoardGameId { get; set; }
        public BoardGameDto BoardGame { get; set; }
        public DateTime PlayedAt { get; set; }
        public int? Duration { get; set; }
        public List<GameSessionPlayerDto> GameSessionPlayers { get; set; } = new List<GameSessionPlayerDto>();
    }
}
