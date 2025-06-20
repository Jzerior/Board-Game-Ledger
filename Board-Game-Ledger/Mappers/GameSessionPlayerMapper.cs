﻿using Board_Game_Ledger.DTOs.GameSessionPlayer;
using Board_Game_Ledger.Models;

namespace Board_Game_Ledger.Mappers
{
    public static class GameSessionPlayerMapper
    {
        public static GameSessionPlayer toGameSessionPlayerFromCreateDto(this CreateGameSessionPlayerRequestDto gameSessionPlayerDTO)
        {
            return new GameSessionPlayer
            {
                Score = gameSessionPlayerDTO.Score,
                Place = gameSessionPlayerDTO.Place,
                IsWinner = gameSessionPlayerDTO.IsWinner,
                Faction = gameSessionPlayerDTO.Faction
            };
        }
        public static GameSessionPlayerDto toDto(this GameSessionPlayer gameSessionPlayer)
        {
            return new GameSessionPlayerDto
            {
                PlayerId = gameSessionPlayer.PlayerId,
                GameSessionId = gameSessionPlayer.GameSessionId,
                Score = gameSessionPlayer.Score,
                Place = gameSessionPlayer.Place,
                IsWinner = gameSessionPlayer.IsWinner,
                Faction = gameSessionPlayer.Faction,
                Player = gameSessionPlayer.Player.toPlayerDTO()

            };
        }
    }
}
