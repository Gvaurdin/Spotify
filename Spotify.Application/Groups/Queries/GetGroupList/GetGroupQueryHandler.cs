using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Spotify.Application.Repositories.RepositoriesDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Groups.Queries.GetGroupList
{
    public class GetGroupQueryHandler(IMapper mapper, ISpotifyDBContext spotifyDBContext) : IRequestHandler<GetGroupListQuery, GroupListViewModel>
    {
        public async Task<GroupListViewModel> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
        {
            var groups = await spotifyDBContext.Groups
                .ProjectTo<GroupLookUpDTO>(mapper.ConfigurationProvider)
                .Skip(request.CountSkipGroups)
                .Take(request.TakeGroups)
                .ToListAsync();
            return new GroupListViewModel
            {
                Groups = groups
            };
        }
    }
}
