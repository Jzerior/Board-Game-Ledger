using System.ComponentModel.DataAnnotations;
using Board_Game_Ledger.DTOs.Player;

namespace Board_Game_Ledger.DTOs.GameSessionPlayer
{
    public class UpdateGameSessionPlayerRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Nazwa gracza musi mieć conajmniej 2 znaki")]
        [MaxLength(280, ErrorMessage = "Nazwa gracza nie może przekroczyć 280 znaków")]
        public string Name { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Miejsce musi być dodatnią liczbą całkowitą")]
        public int? Place { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Wynik nie może być ujemny")]
        public int? Score { get; set; }
        public bool? IsWinner { get; set; }
        [MaxLength(100, ErrorMessage = "Nazwa frakcji nie może przekroczyć 100 znaków")]
        public string? Faction { get; set; }
    }
}
