using Board_Game_Ledger.DTOs.Player;

namespace Board_Game_Ledger.DTOs.GameSessionPlayer
{
    public class GameSessionPlayerDto
    {
        public int GameSessionId { get; set; }
        public int PlayerId { get; set; }
        public PlayerDto Player { get; set; } = null;
        public int? Place { get; set; }
        public int? Score { get; set; }
    }
}
