namespace Board_Game_Ledger.DTOs.GameSessionPlayer
{
    public class CreateGameSessionPlayerRequestDto
    {
        public int PlayerId { get; set; }
        public int? Place { get; set; }
        public int? Score { get; set; }
    }
}
