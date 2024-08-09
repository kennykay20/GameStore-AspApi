using System;
using GameStore.Api.Interfaces;

namespace GameStore.Api.Endpoints;

public static class GenreEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
      var group = app.MapGroup("v1/api/genres");

      group.MapGet("/", async (IGenreService service) => await service.GetGenres());

      return group;
    }
}
