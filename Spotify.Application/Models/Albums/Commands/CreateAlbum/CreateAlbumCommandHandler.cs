using MediatR;
using Spotify.Application.Repositories.RepositoriesAlbum;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandHandler(IRepositoryAlbumCRUD repositoryAlbumCRUD) : IRequestHandler<CreateAlbumCommand,int>
    {
        public async Task<int> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = new Album
            {
                Title = request.Title,
                Description = request.Description
            };
            await repositoryAlbumCRUD.AddAsync(album, cancellationToken);
            return album.Id;
        }
    }
}
