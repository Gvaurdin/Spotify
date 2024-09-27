using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Genres.Queries.GetGenreList
{
    public class GenreListViewModel
    {
        public required IList<GenreLookUpDTO> Genres { get; set; }
    }
}
