using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Spotify.Application.Exceptions;
using Spotify.Application.Repositories.RepositoriesDBContext;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Groups.Queries.GetGroupDetails
{
    public class GetGroupDetailsQueryHandler(ISpotifyDBContext spotifyDBContext, IMapper mapper) : IRequestHandler<GetGroupDetailsQuery, GroupDetailsViewModel>
    {
        public async Task<GroupDetailsViewModel> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
        {
            var group = await spotifyDBContext.Groups.FirstOrDefaultAsync(group => group.Id == request.Id, cancellationToken) ??
                throw new NotFoundException(nameof(Group), request.Id);
            return mapper.Map<GroupDetailsViewModel>(group);
        }
    }
}
