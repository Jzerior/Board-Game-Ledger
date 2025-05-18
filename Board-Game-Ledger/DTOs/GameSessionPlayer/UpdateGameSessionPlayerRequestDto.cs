using Board_Game_Ledger.DTOs.Player;

namespace Board_Game_Ledger.DTOs.GameSessionPlayer
{
    public class UpdateGameSessionPlayerRequestDto
    {
        public int? Place { get; set; }
        public int? Score { get; set; }
    }
}
