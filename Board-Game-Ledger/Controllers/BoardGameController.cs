using Board_Game_Ledger.DTOs.BoardGame;
using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Mappers;
using Board_Game_Ledger.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Board_Game_Ledger.Controllers
{
    [Route("api/boardgame")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        private readonly IBoardGameRepository _bgRepository;
        public BoardGameController(IBoardGameRepository bgRepository)
        {
            _bgRepository = bgRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var boardgames = await _bgRepository.GetAllAsync();
            if (!boardgames.Any())
            {
                return NotFound();
            }
            return Ok(boardgames);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var boardgame = await _bgRepository.GetByIdAsync(id);

            if (boardgame == null)
            {
                return NotFound();
            }
            return Ok(boardgame);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var boardgame = await _bgRepository.DeleteAsync(id);
            if (boardgame == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBoardGameRequestDto boardGameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var boardGame = boardGameDto.toBoardGameFromCreateDTO();
            await _bgRepository.CreateAsync(boardGame);
            return CreatedAtAction(nameof(GetById), new { id = boardGame.Id }, boardGame);
        }
    }
}