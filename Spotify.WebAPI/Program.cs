using Microsoft.EntityFrameworkCore;
using Spotify.Database.Data;
using Spotify.Database.Repositories;
using Spotify.Database.Repositories.Interfaces;
using Spotify.WebAPI;
using Spotify.WebAPI.Filteres;

var host = CreateHostBuilder(args).Build();
host.Run();

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddDbContext<SpotifyDatabaseContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SpotifyDatabaseContext") ??
//    throw new InvalidOperationException("Connection string 'SpotifyDatabaseContext' not found.")));
//builder.Services.AddControllers();
//builder.Services.AddTransient<IGroupRepository, GroupRepository>();
//builder.Services.AddTransient<ISongRepository,SongRepository>();
//builder.Services.AddTransient<IGenreRepository, GenreRepository>();
//builder.Services.AddTransient<IAlbumRepository,AlbumRepository>();
//builder.Services.AddSwaggerGen(c =>
//c.SchemaFilter<ExcludeIdSchemaFilter>());
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    });