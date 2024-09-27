using MediatR;
using Spotify.Application.Exceptions;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Application.Repositories.RepositoriesSong;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Commands.DeleteSong
{
    public class DeleteSongCommandHandler(IRepositorySongCRUD repositorySongCRUD) : IRequestHandler<DeleteSongCommand>
    {
        public async Task Handle(DeleteSongCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new NotFoundException(nameof(Song), request.Id);
            }

            await repositorySongCRUD.RemoveAsync(request.Id, cancellationToken);
        }
    }
}
