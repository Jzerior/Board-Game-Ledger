using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}

