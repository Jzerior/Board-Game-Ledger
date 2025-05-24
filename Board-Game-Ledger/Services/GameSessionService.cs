using Board_Game_Ledger.DTOs.GameSession;
using Board_Game_Ledger.DTOs.Player;
using Board_Game_Ledger.Interfaces.IRepositories;
using Board_Game_Ledger.Interfaces.IServices;
using Board_Game_Ledger.Mappers;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Services
{
    public class GameSessionService : IGameSessionService
    {
        private readonly IGameSessionRepository _gameSessionRepository;
        private readonly IGameSessionPlayerRepository _gameSessionPlayerRepository;
        private readonly IPlayerService _playerService;
        public GameSessionService(IGameSessionRepository gameSessionRepository,
               IGameSessionPlayerRepository gameSessionPlayerRepository,
               IPlayerService playerService)
        {
            _gameSessionRepository = gameSessionRepository;
            _gameSessionPlayerRepository = gameSessionPlayerRepository;
            _playerService = playerService;
        }
        public async Task<GameSession> CreateGameSessionAsync(CreateGameSessionRequestDto dto, string userId)
        {
            var session = dto.toGameSessionFromCreateRequest(userId);
            await _gameSessionRepository.CreateAsync(session);
            int sessionId = session.Id;
            var players = new List<GameSessionPlayer>();
            foreach (var playerDto in dto.GameSessionPlayers)
            {
                var player = await  _playerService.GetByNameOrCreateIfDoesNotExist(playerDto.Name, userId);
                players.Add(new GameSessionPlayer
                {
                    GameSessionId = sessionId,
                    PlayerId = player.Id,
                    Place = playerDto.Place,
                    Score = playerDto.Score
                });
            }
            await _gameSessionPlayerRepository.CreateRangeAsync(players);
            return session;
        }
        public async Task<List<GameSessionDto>> GetAllAsync(string userId) 
        {
           var gameSessions =  await _gameSessionRepository.GetAllAsync(userId);
           return gameSessions.Select(gs => gs.ToDto()).ToList();
        }
        public async Task<GameSessionDto?> GetByIdAsync(int id, string userId)
        {
           var gameSession = await _gameSessionRepository.GetByIdAsync(id, userId);
            if(gameSession == null)
            {
                return null;
            }
           return gameSession.ToDto();
        }
        public async Task<GameSession> DeleteAsync(int id, string userId)
        {
            return await _gameSessionRepository.DeleteAsync(id, userId);
        }

        public async Task<GameSession?> UpdateAsync(int id, UpdateGameSessionRequestDto gameSessionDto, string userId)
        {
            foreach (var playerDto in gameSessionDto.GameSessionPlayers)
            {
                await _playerService.UpdateAsync(playerDto.PlayerId, new UpdatePlayerRequestDto
                {
                    Name= playerDto.Name
                }, userId);
                await _gameSessionPlayerRepository.UpdateAsync(id, playerDto.PlayerId, playerDto);
            }
            return await _gameSessionRepository.UpdateAsync(id, gameSessionDto.toGameSessionFromUpdateRequest(), userId);
        }
    }
}
