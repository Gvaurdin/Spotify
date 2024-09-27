using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Spotify.Application.Models.Groups.Queries.GetGroupList;
using Spotify.Application.Repositories.RepositoriesGenre;
using Spotify.Application.Repositories.RepositoriesGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Genres.Queries.GetGenreList
{
    public class GetGenreListQueryHandler(IMapper mapper, IRepositoryGenreCRUD repositoryGenreCRUD) : IRequestHandler<GetGenreListQuery, GenreListViewModel>
    {
        public async Task<GenreListViewModel> Handle(GetGenreListQuery request, CancellationToken cancellationToken)
        {
            var genres = await repositoryGenreCRUD.GetAllAsync();

            var projectedGenres = genres
                .AsQueryable()
                .ProjectTo<GenreLookUpDTO>(mapper.ConfigurationProvider)
                .Skip(request.CountSkipGenres)
                .Take(request.TakeGenres)
                .ToList();

            return new GenreListViewModel
            {
                Genres = projectedGenres
            };
        }
    }
}
