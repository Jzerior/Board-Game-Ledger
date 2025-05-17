using Board_Game_Ledger.DTOs.GameSessionPlayer;
using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Board_Game_Ledger.Controllers
{
    [Route("api/sessionPlayer")]
    [ApiController]
    public class GameSessionPlayerController : ControllerBase
    {
        private readonly IGameSessionPlayerRepository _gameSessionPlayerRepository;
        public GameSessionPlayerController(IGameSessionPlayerRepository gameSessionPlayerRepository)
        {
            _gameSessionPlayerRepository = gameSessionPlayerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var gameSessionPlayers = await _gameSessionPlayerRepository.GetAllAsync();
            if (!gameSessionPlayers.Any())
            {
                return NotFound();
            }
            return Ok(gameSessionPlayers.Select(gsp => gsp.toDto()));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameSessionPlayerRequestDto gameSessionPlayerDto)
        {
            var createdGameSessionPlayer = await _gameSessionPlayerRepository.CreateAsync(gameSessionPlayerDto.toGameSessionPlayerFromCreateDto());
            return Ok(createdGameSessionPlayer);
        }
        [HttpDelete("{gameSessionId:int}/{playerId:int}")]
        public async Task<IActionResult> Delete(int gameSessionId, int playerId)
        {
            var deletedGameSessionPlayer = await _gameSessionPlayerRepository.DeleteAsync(gameSessionId, playerId);
            if (deletedGameSessionPlayer == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut("{gameSessionId:int}/{playerId:int}")]
        public async Task<IActionResult> Update(int gameSessionId, int playerId, [FromBody] UpdateGameSessionPlayerRequestDto gameSessionPlayerDto)
        {
            var updatedGameSessionPlayer = await _gameSessionPlayerRepository.UpdateAsync(gameSessionId, playerId, gameSessionPlayerDto);
            if (updatedGameSessionPlayer == null)
            {
                return NotFound();
            }
            return Ok(updatedGameSessionPlayer.toDto());
        }
    }
}
