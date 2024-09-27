using MediatR;
using Spotify.Application.Repositories.RepositoriesDBContext;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandHandler(ISpotifyDBContext spotifyDBContext) : IRequestHandler<CreateGroupCommand, int>
    {
        public async Task<int> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new Group
            {
                Title = request.Title,
                Description = request.Description
            };
            await spotifyDBContext.Groups.AddAsync(group,cancellationToken);
            await spotifyDBContext.SaveChangesAsync(cancellationToken);

            return group.Id;
        }
    }
}
