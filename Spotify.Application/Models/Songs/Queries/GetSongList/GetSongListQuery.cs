using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Queries.GetSongList
{
    public class GetSongListQuery : IRequest<SongListViewModel>
    {
        public int CountSkipSongs { get; set; }
        public int TakeSongs { get; set; }
    }
}
