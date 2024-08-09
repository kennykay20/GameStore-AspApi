using System;
using GameStore.Api.DataBaseContext;
using GameStore.Api.Dtos;
using GameStore.Api.Interfaces;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Services;

public class GenreService(GameStoreContext dbContext) : IGenreService
{
    private readonly GameStoreContext _dbContext = dbContext;
    public async Task<List<GenreDetailsDto>> GetGenres()
    {
        var genres = await _dbContext.Genres
              .Select(genre => genre.ToDto())
              .AsNoTracking()
              .ToListAsync();
        return genres;
    }
}
