using System.Security.Claims;
using Board_Game_Ledger.DTOs.GameSession;
using Board_Game_Ledger.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Board_Game_Ledger.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/gamesession")]
    public class GameSessionController : ControllerBase
    {
        private readonly IGameSessionService _gameSessionService;
        public GameSessionController(IGameSessionService gameSessionService)
        {
            _gameSessionService = gameSessionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var gameSessions = await _gameSessionService.GetAllAsync(userId);
            if (!gameSessions.Any())
            {
                return NotFound();
            }
            return Ok(gameSessions);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameSessionRequestDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var session = await _gameSessionService.CreateGameSessionAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id = session.Id }, session);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var session = await _gameSessionService.GetByIdAsync(id, userId);
            if (session == null)
                return NotFound();
            return Ok(session);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var session = await _gameSessionService.DeleteAsync(id, userId);
            if (session == null)
                return NotFound();
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGameSessionRequestDto gameSession)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var updatedSession = await _gameSessionService.UpdateAsync(id, gameSession, userId);
            if (updatedSession == null)
                return NotFound();
            return Ok(updatedSession);
        }
    }
}
