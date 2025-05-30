using System.ComponentModel.DataAnnotations.Schema;

namespace Board_Game_Ledger.Models
{
    [Table("GameSessionPlayers")]
    public class GameSessionPlayer
    {
        
        public int GameSessionId { get; set; }
        public GameSession GameSession { get; set; } = null!;
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        public int? Place { get; set; } //For games with traditional scoring
        public bool? IsWinner { get; set; } //For games without points and to simplify calculating of winratio
        public string? Faction { get; set; } //Will have to think about liniking it somehow to boardgames to avoid typos and confusion
        public int? Score { get; set; }
    }
}
