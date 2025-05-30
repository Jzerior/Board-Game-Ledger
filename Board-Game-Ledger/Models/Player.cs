using System.ComponentModel.DataAnnotations.Schema;

namespace Board_Game_Ledger.Models
{
    [Table("Players")]
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string? AssociatedUserId { get; set; }
        public AppUser? AssociatedUser { get; set; }
        public List<GameSessionPlayer> Sessions { get; set; } = new List<GameSessionPlayer>();

    }
}
