using AutoMapper;
using MediatR;
using Spotify.Application.Exceptions;
using Spotify.Application.Models.Groups.Queries.GetGroupDetails;
using Spotify.Application.Repositories.RepositoriesGenre;
using Spotify.Application.Repositories.RepositoriesGroup;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Queries.GetSongDetails
{
    public class GetGenreDetailsQueryHandler(IMapper mapper, IRepositoryGenreCRUD repositoryGenreCRUD) : IRequestHandler<GetGenreDetailsQuery, GenreDetailsViewModel>
    {
        public async Task<GenreDetailsViewModel> Handle(GetGenreDetailsQuery request, CancellationToken cancellationToken)
        {
            var projectGroup = await repositoryGenreCRUD.GetByIdAsync(request.Id, cancellationToken) ??
                 throw new NotFoundException(nameof(Genre), request.Id);
            return mapper.Map<GenreDetailsViewModel>(projectGroup);
        }
    }
}
