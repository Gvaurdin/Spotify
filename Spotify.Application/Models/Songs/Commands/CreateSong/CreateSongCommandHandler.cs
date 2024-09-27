using MediatR;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Application.Repositories.RepositoriesSong;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Commands.CreateSong
{
    public class CreateSongCommandHandler(IRepositorySongCRUD repositorySongCRUD) : IRequestHandler<CreateSongCommand, int>
    {
        public async Task<int> Handle(CreateSongCommand request, CancellationToken cancellationToken)
        {
            var song = new Song
            {
                Title = request.Title,
                Description = request.Description
            };
            await repositorySongCRUD.AddAsync(song, cancellationToken);
            return song.Id;
        }
    }
}
