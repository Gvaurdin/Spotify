using Spotify.Application.Models.Groups.Queries.GetGroupDetails;
using Spotify.Application.Models.Groups.Queries.GetGroupList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Repositories.RepositoriesGroup
{
    public interface IRepositoryGroup
    {
        Task<GroupListViewModel> GetGroupListRange(GetGroupListQuery query, CancellationToken cancellationToken);
        Task<GroupDetailsViewModel> GetGroupDetailsRange(GetGroupDetailsQuery query, CancellationToken cancellationToken);
    }
}
