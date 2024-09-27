using AutoMapper;
using MediatR;
using Spotify.Application.Exceptions;
using Spotify.Application.Models.Groups.Queries.GetGroupDetails;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Application.Repositories.RepositoriesSong;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Queries.GetSongDetails
{
    public class GetSongDetailsQueryHandler(IMapper mapper, IRepositorySongCRUD repositorySongCRUD) : IRequestHandler<GetSongDetailsQuery, SongDetailsViewModel>
    {
        public async Task<SongDetailsViewModel> Handle(GetSongDetailsQuery request, CancellationToken cancellationToken)
        {
            var projectGroup = await repositorySongCRUD.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundException(nameof(Song), request.Id);
            return mapper.Map<SongDetailsViewModel>(projectGroup);
        }
    }
}
