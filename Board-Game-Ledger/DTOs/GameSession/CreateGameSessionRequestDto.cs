using Board_Game_Ledger.DTOs.GameSessionPlayer;

namespace Board_Game_Ledger.DTOs.GameSession
{
    public class CreateGameSessionRequestDto
    {
        public int BoardGameId { get; set; }
        public DateTime PlayedAt { get; set; }
        public int? Duration { get; set; }
        public List<CreateGameSessionPlayerRequestDto> GameSessionPlayers { get; set; } = new List<GameSessionPlayer>();
    }
}
}
