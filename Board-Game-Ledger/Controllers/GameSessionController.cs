using Board_Game_Ledger.DTOs.GameSession;
using Board_Game_Ledger.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Board_Game_Ledger.Controllers
{
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
            var gameSessions = await _gameSessionService.GetAllAsync();
            if (!gameSessions.Any())
            {
                return NotFound();
            }
            return Ok(gameSessions);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameSessionRequestDto dto)
        {
            var session = await _gameSessionService.CreateGameSessionAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = session.Id }, session);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var session = await _gameSessionService.GetByIdAsync(id);
            if (session == null)
                return NotFound();
            return Ok(session);
        }
    }
}
