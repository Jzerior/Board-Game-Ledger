using System.ComponentModel.DataAnnotations;

namespace Board_Game_Ledger.DTOs.Player
{
    public class CreatePlayerRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Nazwa gracza musi mieć conajmniej 2 znaki")]
        [MaxLength(280, ErrorMessage = "Nazwa gracza nie może przekroczyć 280 znaków")]
        public string Name { get; set; } = string.Empty;
    }
}
