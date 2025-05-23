﻿using System.Security.Claims;
using Board_Game_Ledger.DTOs.Player;
using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Interfaces.IServices;
using Board_Game_Ledger.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Board_Game_Ledger.Controllers
{
    [Authorize]
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerRepository playerRepository, IPlayerService playerService)
        {
            _playerRepository = playerRepository;
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var players = await _playerRepository.GetAllAsync(userId);
            if (!players.Any())
            {
                return NotFound();
            }
            return Ok(players);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var player = await _playerRepository.GetByIdAsync(id, userId);

            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var player = await _playerRepository.DeleteAsync(id, userId);
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var createdPlayer = await _playerRepository.CreateAsync(playerDto.toPlayerFromCreateDTO(userId));
            return CreatedAtAction(nameof(GetById), new { id = createdPlayer.Id }, createdPlayer);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByNameOrCreateIfDoesNotExist([FromRoute] string name, string userId)
        {
            var player = await _playerService.GetByNameOrCreateIfDoesNotExist(name, userId);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdatePlayerRequestDto playerDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var player = await _playerRepository.UpdateAsync(id,playerDto, userId);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player.toPlayerDTO());
        }
    }
}
