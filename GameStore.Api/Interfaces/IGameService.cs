using System;
using System.Collections.Generic;
using GameStore.Api.Dtos;

namespace GameStore.Api.Interfaces;

public interface IGameService
{
  Task<GameDetailsDto?> GetGameById(int id);

  Task<List<GameDetailsDto>> GetGames();

  Task<GameDetailsDto> AddGame(CreateGameDto data);

  void DeleteGameById(int id);

  Task<GameDetailsDto?> UpdateGameById(UpdateGameDto data, int id);
}
