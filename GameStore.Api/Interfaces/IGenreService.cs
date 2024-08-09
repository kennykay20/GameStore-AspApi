using System;
using GameStore.Api.Dtos;

namespace GameStore.Api.Interfaces;

public interface IGenreService
{
    Task<List<GenreDetailsDto>> GetGenres();
}
