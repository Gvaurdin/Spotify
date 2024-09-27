using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Queries.GetSongList
{
    public class SongListViewModel
    {
        public required IList<SongLookUpDTO> Songs { get; set; }
    }
}
