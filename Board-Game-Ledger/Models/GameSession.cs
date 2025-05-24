using System.ComponentModel.DataAnnotations.Schema;

namespace Board_Game_Ledger.Models
{
    [Table("GameSessions")]
    public class GameSession
    {
        public int Id { get; set; }
        public int BoardGameId { get; set; }
        public BoardGame BoardGame { get; set; }
        public DateTime PlayedAt { get; set; }
        public int PlayerCount { get; set; }
        public int? Duration { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<GameSessionPlayer> GameSessionPlayers { get; set; } = new List<GameSessionPlayer>();
    }
}
