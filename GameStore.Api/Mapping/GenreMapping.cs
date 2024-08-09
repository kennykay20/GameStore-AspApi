using System;
using GameStore.Api.Dtos;
using GameStore.Api.Models;

namespace GameStore.Api.Mapping;

public static class GenreMapping
{
    public static GenreDetailsDto ToDto(this Genre genre)
    {
       return new GenreDetailsDto(genre.Id, genre.Name);
    }
}
