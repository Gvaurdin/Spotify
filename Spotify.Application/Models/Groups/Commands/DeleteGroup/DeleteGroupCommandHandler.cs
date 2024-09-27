using MediatR;
using MediatR.Pipeline;
using Spotify.Application.Exceptions;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommandHandler(IRepositoryGroupCRUD repositoryGroupCRUD) : IRequestHandler<DeleteGroupCommand>
    {
        public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            //var group = await repositoryGroupCRUD.GetByIdAsync(request.Id, cancellationToken);
            if (request.Id == 0)
            {
                throw new NotFoundException(nameof(Group), request.Id);
            }

            await repositoryGroupCRUD.RemoveAsync(request.Id, cancellationToken);
        }
    }
}
