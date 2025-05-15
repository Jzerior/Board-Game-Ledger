using System.ComponentModel.DataAnnotations.Schema;

namespace Board_Game_Ledger.Models
{
    [Table("Players")]
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<GameSessionPlayer> Sessions { get; set; } = new List<GameSessionPlayer>();

    }
}
