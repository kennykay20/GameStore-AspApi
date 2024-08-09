using GameStore.Api.DataBaseContext;
using GameStore.Api.Endpoints;
using GameStore.Api.Interfaces;
using GameStore.Api.Services;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");

System.Console.WriteLine(connString);
builder.Services.AddSqlite<GameStoreContext>(connString);
// AddTransient lifetime services are created each time the are requested from the service container (IServiceProvide)
// AddScope lifetime services are created once per HTTP requested and reused within that request.
// AddSingleton lifetime services are created the first time they are requested and reused across the application lifetime until it is shortdown
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGenreService, GenreService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGamesEndpoints();

app.MapGenresEndpoints();

await app.MigrateDbAsync();

app.Run();
