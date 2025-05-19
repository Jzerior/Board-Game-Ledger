using System.ComponentModel.DataAnnotations;

namespace Board_Game_Ledger.DTOs.Account
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
