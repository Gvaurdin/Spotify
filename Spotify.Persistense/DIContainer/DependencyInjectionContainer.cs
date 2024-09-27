using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Application.Repositories.RepositoriesAlbum;
using Spotify.Application.Repositories.RepositoriesDBContext;
using Spotify.Application.Repositories.RepositoriesGenre;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Application.Repositories.RepositoriesSong;
using Spotify.Persistense.Repositories.RepositoriesAlbum;
using Spotify.Persistense.Repositories.RepositoriesGenre;
using Spotify.Persistense.Repositories.RepositoriesGroup;
using Spotify.Persistense.Repositories.RepositoriesSong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Persistense.DIContainer
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<SpotifyDatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IRepositoryGroupCRUD, RepositoryGroupCRUD>();
            services.AddScoped<IRepositoryAlbumCRUD, RepositoryAlbumCRUD>();
            services.AddScoped<IRepositorySongCRUD, RepositorySongCRUD>();
            services.AddScoped<IRepositoryGenreCRUD, RepositoryGenreCRUD>();
            return services;
        }
    }
}
