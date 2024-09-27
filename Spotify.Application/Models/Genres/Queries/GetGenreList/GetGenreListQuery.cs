using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Genres.Queries.GetGenreList
{
    public class GetGenreListQuery : IRequest<GenreListViewModel>
    {
        public int CountSkipGenres { get; set; }
        public int TakeGenres { get; set; }
    }
}
