using System.ComponentModel.DataAnnotations;

namespace Board_Game_Ledger.DTOs.BoardGame
{
    public class UpdateBoardGameRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Tytuł gry planszowej musi mieć conajmniej 2 znaki")]
        [MaxLength(280, ErrorMessage = "Tytuł gry planszowej nie może przekroczyć 280 znaków")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage = "Gatunek gry planszowej musi mieć conajmniej 2 znaki")]
        [MaxLength(280, ErrorMessage = "Gatunek gry planszowej nie może przekroczyć 280 znaków")]
        public string Genre { get; set; } = string.Empty;
        [Required]
        [Range(1, 20, ErrorMessage = "Minimalna iczba graczy nie może być mniejsza od 1 i większa od 20")]
        public int MinPlayerCount { get; set; }
        [Required]
        [Range(1, 20, ErrorMessage = "Maksymalna iczba graczy nie może być mniejsza od 1 i większa od 20")]
        public int MaxPlayerCount { get; set; }
    }
}
