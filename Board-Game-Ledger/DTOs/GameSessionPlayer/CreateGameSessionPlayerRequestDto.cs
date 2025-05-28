using System.ComponentModel.DataAnnotations;

namespace Board_Game_Ledger.DTOs.GameSessionPlayer
{
    public class CreateGameSessionPlayerRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Nazwa gracza musi mieć conajmniej 2 znaki")]
        [MaxLength(280, ErrorMessage = "Nazwa gracza nie może przekroczyć 280 znaków")]
        public string Name { get; set; } = string.Empty;
        public int? Place { get; set; }
        public int? Score { get; set; }
        public bool? IsWinner { get; set; } 
        public string? Faction { get; set; }
    }
}
