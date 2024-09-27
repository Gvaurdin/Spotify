using MediatR;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Application.Repositories.RepositoriesSong;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Commands.UpdateSong
{
    public class UpdateSongCommandHandler(IRepositorySongCRUD repositorySongCRUD) : IRequestHandler<UpdateSongCommand>
    {
        public async Task Handle(UpdateSongCommand request, CancellationToken cancellationToken)
        {
            var song = new Song
            {
                Title = request.Title,
                Description = request.Description
            };
            await repositorySongCRUD.UpdateAsync(request.Id, song, cancellationToken);
        }
    }
}
