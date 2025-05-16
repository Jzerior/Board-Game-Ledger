using Board_Game_Ledger.DTOs.Player;
using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Mappers;
using Board_Game_Ledger.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Board_Game_Ledger.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerController(IPlayerRepository playerRepository)
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlayerRequestDto playerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdPlayer = await _playerRepository.CreateAsync(playerDto.toPlayerFromCreateDTO());
            return CreatedAtAction(nameof(GetById), new { id = createdPlayer.Id }, createdPlayer);
        }
    }
}
