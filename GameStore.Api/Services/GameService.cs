using System;
using GameStore.Api.DataBaseContext;
using GameStore.Api.Dtos;
using GameStore.Api.Interfaces;
using GameStore.Api.Mapping;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Services;

public class GameService(GameStoreContext dbContext) : IGameService
{
    private readonly GameStoreContext _dbContext = dbContext;

    public async Task<GameDetailsDto> AddGame(CreateGameDto newGame)
    {
        Game game = newGame.ToEntity();
        _dbContext.Games.Add(game);
        await _dbContext.SaveChangesAsync();

        return game.ToGameDetailsDto();
    }

    public async Task<GameDetailsDto?> GetGameById(int id)
    {
        Game? game = await _dbContext.Games.FindAsync(id);
        return game?.ToGameDetailsDto();
    }

    public async Task<List<GameDetailsDto>> GetGames()
    {
      var games = await _dbContext.Games
                  .Include(game => game.Genre)
                  .Select((game) => game.ToGameDetailsDto())
                  .AsNoTracking()
                  .ToListAsync();
      return games;
    }

    public async Task<GameDetailsDto?> UpdateGameById(UpdateGameDto data, int id)
    {
        var existingGame = await _dbContext.Games.FindAsync(id);

        if (existingGame is null)
        {
          return null;
        }
        Game updatedGame = data.ToUpdateEntity(id);

        _dbContext.Entry(existingGame)
                  .CurrentValues
                  .SetValues(updatedGame);
        await _dbContext.SaveChangesAsync();

        return updatedGame.ToGameDetailsDto();
    }
    public async void DeleteGameById(int id)
    {
        await _dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();
    }
}
