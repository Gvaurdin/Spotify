using MediatR;
using Spotify.Application.Repositories.RepositoriesDBContext;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandHandler(IRepositoryGroupCRUD repositoryGroupCRUD) : IRequestHandler<CreateGroupCommand, int>
    {
        public async Task<int> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new Group
            {
                Title = request.Title,
                Description = request.Description
            };
            await repositoryGroupCRUD.AddAsync(group, cancellationToken);
            return group.Id;
        }
    }
}
