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
        public int Place { get; set; }
        public int? Score { get; set; }
    }
}
