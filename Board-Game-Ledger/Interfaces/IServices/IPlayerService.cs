using Board_Game_Ledger.DTOs.Player;

namespace Board_Game_Ledger.Interfaces.IServices
{
    public interface IPlayerService
    {
        Task<PlayerDto> GetByNameOrCreateIfDoesNotExist(string name);
    }
}
