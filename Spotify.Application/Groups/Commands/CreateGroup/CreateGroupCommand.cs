using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest<int>
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
