using Board_Game_Ledger.DTOs.GameSession;
using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Interfaces.IServices;
using Board_Game_Ledger.Mappers;
using Board_Game_Ledger.Models;
using Microsoft.EntityFrameworkCore;

namespace Board_Game_Ledger.Services
{
    public class GameSessionService : IGameSessionService
    {
        private readonly IGameSessionRepository _gameSessionRepository;
        public GameSessionService(IGameSessionRepository gameSessionRepository)
        {
            _gameSessionRepository = gameSessionRepository;
        }
        public async Task<GameSession> CreateGameSessionAsync(CreateGameSessionRequestDto dto)
        {
            var session = new GameSession
            {
                BoardGameId = dto.BoardGameId,
                PlayedAt = dto.PlayedAt,
                Duration = dto.Duration,
                GameSessionPlayers = new List<GameSessionPlayer>()
            };

            foreach (var playerDto in dto.GameSessionPlayers)
            {

                //if (playerDto.PlayerId.HasValue)
                //{
                //    var existingPlayer = await _playerRepository.GetByIdAsync(playerDto.PlayerId.Value);
                //    if (existingPlayer == null)
                //        throw new Exception($"Player with ID {playerDto.PlayerId} not found.");
                //    playerId = existingPlayer.Id;
                //}
                //else
                //{
                //    if (string.IsNullOrWhiteSpace(playerDto.Name))
                //        throw new Exception("Player name is required for new players.");

                //    var existing = await _context.Players
                //        .FirstOrDefaultAsync(p => p.Name == playerDto.Name);

                //    if (existing != null)
                //        playerId = existing.Id;
                //    else
                //    {
                //        var newPlayer = new Player { Name = playerDto.Name };
                //        _context.Players.Add(newPlayer);
                //        await _context.SaveChangesAsync();
                //        playerId = newPlayer.Id;
                //    }
                //}

                session.GameSessionPlayers.Add(new GameSessionPlayer
                {
                    PlayerId = playerDto.PlayerId,
                    Place = playerDto.Place,
                    Score = playerDto.Score
                });
            }
            return session;
        }
        public async Task<List<GameSessionDto>> GetAllAsync() 
        {
           var gameSessions =  await _gameSessionRepository.GetAllAsync();
           return gameSessions.Select(gs => gs.ToDto()).ToList();
        }
        public async Task<GameSessionDto?> GetByIdAsync(int id)
        {
           var gameSession = await _gameSessionRepository.GetByIdAsync(id);
           return gameSession.ToDto();
        }

    }
}
