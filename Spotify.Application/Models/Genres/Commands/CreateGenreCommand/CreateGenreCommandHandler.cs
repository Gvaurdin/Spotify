using MediatR;
using Spotify.Application.Repositories.RepositoriesGenre;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Genres.Commands.CreateGenreCommand
{
    public class CreateGenreCommandHandler(IRepositoryGenreCRUD repositoryGenreCRUD) : IRequestHandler<CreateGenreCommand, int>
    {
        public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                Title = request.Title
            };
            await repositoryGenreCRUD.AddAsync(genre, cancellationToken);
            return genre.Id;
        }
    }
}
