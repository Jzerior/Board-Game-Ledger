using Board_Game_Ledger.DTOs.GameSessionPlayer;
using System.ComponentModel.DataAnnotations;

namespace Board_Game_Ledger.DTOs.GameSession
{
    public class UpdateGameSessionRequestDto
    {
        [Required]
        public int BoardGameId { get; set; }
        [Required]
        public DateTime PlayedAt { get; set; }
        [Required]
        [Range(1, 9999, ErrorMessage = "Czas gry nie może być krótszy niż 1 minuta i dłuższy niż 9999 minut")]
        public int? Duration { get; set; }
        public string? Description { get; set; }
        public List<UpdateGameSessionPlayerRequestDto> GameSessionPlayers { get; set; } = new List<UpdateGameSessionPlayerRequestDto>();
    }
}
