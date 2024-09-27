using MediatR;
using Spotify.Application.Exceptions;
using Spotify.Application.Repositories.RepositoriesGenre;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Genres.Commands.DeleteGenreCommand
{
    public class DeleteGenreCommandHandler(IRepositoryGenreCRUD repositoryGenreCRUD) : IRequestHandler<DeleteGenreCommand>
    {
        public async Task Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new NotFoundException(nameof(Genre), request.Id);
            }

            await repositoryGenreCRUD.RemoveAsync(request.Id, cancellationToken);
        }
    }
}
