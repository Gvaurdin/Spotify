using AutoMapper;
using MediatR;
using Spotify.Application.Exceptions;
using Spotify.Application.Models.Groups.Queries.GetGroupDetails;
using Spotify.Application.Repositories.RepositoriesAlbum;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Queries.GetAlbumDetails
{
    public class GetAlbumDetailsQueryHandler(IMapper mapper, IRepositoryAlbumCRUD repositoryAlbumCRUD) : IRequestHandler<GetAlbumDetailsQuery, AlbumDetailsViewModel>
    {
        public async Task<AlbumDetailsViewModel> Handle(GetAlbumDetailsQuery request, CancellationToken cancellationToken)
        {
            var projectGroup = await repositoryAlbumCRUD.GetByIdAsync(request.Id, cancellationToken) ??
                 throw new NotFoundException(nameof(Album), request.Id);
            return mapper.Map<AlbumDetailsViewModel>(projectGroup);
        }
    }
}
