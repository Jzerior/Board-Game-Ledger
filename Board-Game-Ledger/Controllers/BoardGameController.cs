using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Board_Game_Ledger.Controllers
{
    [Route("api/boardgame")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        private readonly IBoardGameRepository _bgRepository;
        public BoardGameController(BoardGameRepository bgRepository)
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
    }
}