using System.ComponentModel.DataAnnotations;
using Board_Game_Ledger.DTOs.GameSessionPlayer;

namespace Board_Game_Ledger.DTOs.GameSession
{
    public class CreateGameSessionRequestDto
    {
        [Required]
        public int BoardGameId { get; set; }
        [Required]
        public DateTime PlayedAt { get; set; }
        [Required]
        [Range(1, 9999, ErrorMessage = "Czas gry nie może być krótszy niż 1 minuta i dłuższy niż 9999 minut")]
        public int? Duration { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Lista graczy jest wymagana")]
        [MinLength(1, ErrorMessage = "Sesja musi zawierać przynajmniej jednego gracza")]
        public List<CreateGameSessionPlayerRequestDto> GameSessionPlayers { get; set; } = new List<CreateGameSessionPlayerRequestDto>();
    }
}
