using Movie.API.Clients;
using Movie.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IOmdbClient, OmdbClient>(x => 
    x.BaseAddress = new Uri("https://www.omdbapi.com"));

builder.Services.AddSingleton<IWatchedMoviesService, WatchedMoviesService>();
builder.Services.AddSingleton<IWatchListServices, WatchListServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
