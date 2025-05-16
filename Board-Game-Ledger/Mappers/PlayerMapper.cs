using Board_Game_Ledger.DTOs.Player;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Mappers
{
    public static class PlayerMapper
    {
        public static Player toPlayerFromCreateDTO(this CreatePlayerRequestDto playerDto)
        {
            return new Player
            {
                Name = playerDto.Name,
            };
        }
    }
}
