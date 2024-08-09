using System;
using GameStore.Api.DataBaseContext;
using GameStore.Api.Dtos;
using GameStore.Api.Interfaces;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
  const string GetCameEndpoint = "GetGame";
  public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("v1/api/games")
      .WithParameterValidation();
    // GET games
    group.MapGet("/", async (IGameService service) => await service.GetGames());

    // GET games/id
    group.MapGet("/{id}", async (IGameService service, int id) => {
        GameDetailsDto? result = await service.GetGameById(id);
        return result is null ? Results.NotFound() : Results.Ok(result);
    }).WithName(GetCameEndpoint);

    // POST games
    group.MapPost("/", async (IGameService service, CreateGameDto newGame) => {
      var game = await service.AddGame(newGame);
      System.Console.WriteLine($"game Post {game.Name}: {game.Id} : {game.Price} : {game.ReleaseDate}");
      return Results.CreatedAtRoute(GetCameEndpoint, new { id = game.Id }, game);
    });

    // PUT games/id
    group.MapPut("/{id}", async (IGameService service, UpdateGameDto game, int id) => {
      var result = await service.UpdateGameById(game, id);
      return result is null ? Results.NotFound() : Results.Ok(result);
    });

    // DELETE games/id
    group.MapDelete("/{id}", (int id, IGameService service) => {
      service.DeleteGameById(id);
      return Results.NoContent();
    });

    return group;
  }
}
