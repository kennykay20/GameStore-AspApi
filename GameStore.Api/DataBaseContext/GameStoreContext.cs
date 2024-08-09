using System;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.DataBaseContext;

public class GameStoreContext(DbContextOptions<GameStoreContext> dbContext) 
  : DbContext(dbContext)
{
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
          new {Id = 1, Name = "Football"},
          new { Id = 2, Name = "Fighting" },
          new { Id = 3, Name = "RolePlaying" },
          new { Id = 4, Name = "Racing" },
          new { Id = 5, Name = "Kids and Family" } 
        );
    }
}
