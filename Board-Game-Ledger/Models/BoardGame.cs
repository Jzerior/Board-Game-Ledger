using System.ComponentModel.DataAnnotations.Schema;

namespace Board_Game_Ledger.Models
{
    [Table("BoardGames")]
    public class BoardGame
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int MinPlayerCount { get; set; }
        public int MaxPlayerCount { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<GameSession> Sessions { get; set; }
    }
}
