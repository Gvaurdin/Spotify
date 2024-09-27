using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Groups.Queries.GetGroupList
{
    public class GetGroupListQuery : IRequest<GroupListViewModel>
    {
        public int CountSkipGroups { get; set; }
        public int TakeGroups { get; set; }
    }
}
