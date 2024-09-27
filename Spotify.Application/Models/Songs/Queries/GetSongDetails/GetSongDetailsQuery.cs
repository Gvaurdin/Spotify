using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Queries.GetSongDetails
{
    public class GetSongDetailsQuery: IRequest<SongDetailsViewModel>
    {
        public int Id { get; set; }
    }
}
