using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Spotify.Application.Exceptions;
using Spotify.Application.Models.Groups.Queries.GetGroupDetails;
using Spotify.Application.Models.Groups.Queries.GetGroupList;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spotify.Persistense.Repositories.RepositoriesGroup
{
    public class RepositoryGroupEF(SpotifyDatabaseContext spotifyDatabaseContext, IMapper mapper) : IRepositoryGroup
    {
        public async Task<GroupListViewModel> GetGroupListRange(GetGroupListQuery query, CancellationToken cancellationToken)
        {
            var groups = await spotifyDatabaseContext.Groups
                .ProjectTo<GroupLookUpDTO>(mapper.ConfigurationProvider)
                .Skip(query.CountSkipGroups)
                .Take(query.TakeGroups)
                .ToListAsync(cancellationToken);
            return new GroupListViewModel
            {
                Groups = groups
            };

        }

        public async Task<GroupDetailsViewModel> GetGroupDetailsRange(GetGroupDetailsQuery query, CancellationToken cancellationToken)
        {
            var group = await spotifyDatabaseContext.Groups.FirstOrDefaultAsync(group => group.Id == query.Id, cancellationToken) ??
                throw new NotFoundException(nameof(Group), query.Id);
            return mapper.Map<GroupDetailsViewModel>(group);
        }
    }
}
