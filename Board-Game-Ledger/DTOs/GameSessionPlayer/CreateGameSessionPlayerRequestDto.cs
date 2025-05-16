using System.ComponentModel.DataAnnotations;

namespace Board_Game_Ledger.DTOs.GameSessionPlayer
{
    public class CreateGameSessionPlayerRequestDto
    {
        //[Required]
        //[MinLength(2, ErrorMessage = "Nazwa gracza musi mieć conajmniej 2 znaki")]
        //[MaxLength(280, ErrorMessage = "Nazwa gracza nie może przekroczyć 280 znaków")]
        //public string Name { get; set; } = string.Empty;
        //[Required]
        //public int GameSessionId { get; set; }
        [Required]
        public int PlayerId { get; set; }
        public int? Place { get; set; }
        public int? Score { get; set; }
    }
}
