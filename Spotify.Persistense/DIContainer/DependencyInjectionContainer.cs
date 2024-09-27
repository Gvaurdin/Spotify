using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Application.Repositories.RepositoriesDBContext;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Persistense.Repositories.RepositoriesGroup;
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
            return services;
        }
    }
}
