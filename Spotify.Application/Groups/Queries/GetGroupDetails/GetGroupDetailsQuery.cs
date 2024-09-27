using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Groups.Queries.GetGroupDetails
{
    public class GetGroupDetailsQuery : IRequest<GroupDetailsViewModel>
    {
        public int Id { get; set; }

    }
}
