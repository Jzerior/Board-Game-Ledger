using Board_Game_Ledger.DTOs.Player;
using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Interfaces.IServices;
using Board_Game_Ledger.Mappers;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public async Task<PlayerDto> GetByNameOrCreateIfDoesNotExist(string name)
        {
            var player = await _playerRepository.GetByNameAsync(name);
            if (player == null)
            {
                player  = await _playerRepository.CreateAsync(new Models.Player
                {
                    Name = name
                });
            }
            return player.toPlayerDTO();
        }
        public async Task<PlayerDto> UpdateAsync(int id, UpdatePlayerRequestDto playerDto)
        {
            var player = await _playerRepository.UpdateAsync(id, playerDto);
            return player.toPlayerDTO();
        }
    }
}
