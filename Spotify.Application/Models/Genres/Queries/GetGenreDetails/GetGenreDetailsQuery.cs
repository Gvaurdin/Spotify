using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Queries.GetSongDetails
{
    public class GetGenreDetailsQuery: IRequest<GenreDetailsViewModel>
    {
        public int Id { get; set; }
    }
}
