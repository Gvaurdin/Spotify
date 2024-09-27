using MediatR;
using Spotify.Application.Repositories.RepositoriesAlbum;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommandHandler(IRepositoryAlbumCRUD repositoryAlbumCRUD) : IRequestHandler<UpdateAlbumCommand>
    {
        public async Task Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = new Album
            {
                Title = request.Title,
                Description = request.Description
            };
            await repositoryAlbumCRUD.UpdateAsync(request.Id, album, cancellationToken);
        }
    }
}
