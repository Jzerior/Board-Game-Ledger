using System.ComponentModel.DataAnnotations;

namespace Board_Game_Ledger.DTOs.Account
{
    public class NewUserDto
    {
        public string Username { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
