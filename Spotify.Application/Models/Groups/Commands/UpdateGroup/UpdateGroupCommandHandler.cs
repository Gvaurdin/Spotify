using MediatR;
using Spotify.Application.Exceptions;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandHandler(IRepositoryGroupCRUD repositoryGroupCRUD): IRequestHandler<UpdateGroupCommand>
    {
        public async Task Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new Group
            {
                Title = request.Title,
                Description = request.Description
            };
            await repositoryGroupCRUD.UpdateAsync(request.Id,group, cancellationToken);

        }
    }
}
