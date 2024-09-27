using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Queries.GetAlbumList
{
    public class AlbumListViewModel
    {
        public required IList<AlbumLookUpDTO> Albums { get; set; }
    }
}
