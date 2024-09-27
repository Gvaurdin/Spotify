using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Application.Models.Albums.Commands.CreateAlbum;
using Spotify.Application.Models.Albums.Commands.UpdateAlbum;
using Spotify.Application.Models.Behavior;
using Spotify.Application.Models.Genres.Commands.CreateGenreCommand;
using Spotify.Application.Models.Genres.Commands.UpdateGenreCommand;
using Spotify.Application.Models.Groups.Commands.CreateGroup;
using Spotify.Application.Models.Groups.Commands.UpdateGroup;
using Spotify.Application.Models.Songs.Commands.CreateSong;
using Spotify.Application.Models.Songs.Commands.UpdateSong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.DIContainer
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
