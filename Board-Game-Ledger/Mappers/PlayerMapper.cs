using Board_Game_Ledger.DTOs.Player;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Mappers
{
    public static class PlayerMapper
    {
        public static Player toPlayerFromCreateDTO(this CreatePlayerRequestDto playerDto, string appUserId)
        {
            return new Player
            {
                Name = playerDto.Name,
                AppUserId = appUserId
            };
        }
        public static PlayerDto toPlayerDTO(this Player player)
        {
            return new PlayerDto
            {
                Id = player.Id,
                Name = player.Name,
            };
        }
    }
}
