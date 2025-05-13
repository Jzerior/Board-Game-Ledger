using System.ComponentModel.DataAnnotations.Schema;

namespace Board_Game_Ledger.Models
{
    [Table("BoardGames")]
    public class BoardGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int MinPlayerCount { get; set; }
        public int MaxPlayerCount { get; set; }
    }
}
