using Microsoft.AspNetCore.Identity;

namespace Board_Game_Ledger.Models
{
    public class AppUser : IdentityUser
    {
        public List<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
        public List<GameSession> GameSessions { get; set; } = new List<GameSession>();
        public List<Player> Players { get; set; } = new List<Player>();
    }
}
