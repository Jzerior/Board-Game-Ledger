using System.ComponentModel.DataAnnotations.Schema;

namespace Board_Game_Ledger.Models
{
    [Table("GameRecords")]
    public class GameRecord
    {
        public int BoardGameId { get; set; }
        public int PlayerId {get; set; }
        public BoardGame BoardGame { get; set; }
        public Player Player { get; set; }
        public int PlaceTaken { get; set; }
        public DateTime PlayedOn { get; set; }
    }
}
