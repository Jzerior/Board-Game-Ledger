using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Board_Game_Ledger.Controllers
{
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepostiory _playerRepository;
        public PlayerController(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await _playerRepository.GetAllAsync();
            if (!players.Any())
            {
                return NotFound();
            }
            return Ok(players);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var player = await _playerRepository.GetByIdAsync(id);

            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var player = await _playerRepository.DeleteAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
