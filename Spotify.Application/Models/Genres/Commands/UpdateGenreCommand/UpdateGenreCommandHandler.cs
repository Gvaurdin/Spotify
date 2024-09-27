using MediatR;
using Spotify.Application.Repositories.RepositoriesGenre;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Genres.Commands.UpdateGenreCommand
{
    public class UpdateGenreCommandHandler(IRepositoryGenreCRUD repositoryGenreCRUD) : IRequestHandler<UpdateGenreCommand>
    {
        public async Task Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                Title = request.Title
            };
            await repositoryGenreCRUD.UpdateAsync(request.Id, genre, cancellationToken);
        }
    }
}
