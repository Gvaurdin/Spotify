using MediatR;
using Spotify.Application.Exceptions;
using Spotify.Application.Repositories.RepositoriesAlbum;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumCommandHandler(IRepositoryAlbumCRUD repositoryAlbumCRUD) : IRequestHandler<DeleteAlbumCommand>
    {
        public async Task Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new NotFoundException(nameof(Album), request.Id);
            }

            await repositoryAlbumCRUD.RemoveAsync(request.Id, cancellationToken);
        }
    }
}
