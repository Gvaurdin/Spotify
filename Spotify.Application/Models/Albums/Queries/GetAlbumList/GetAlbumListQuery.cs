using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Queries.GetAlbumList
{
    public class GetAlbumListQuery : IRequest<AlbumListViewModel>
    {
        public int CountSkipAlbums { get; set; }
        public int TakeAlbums { get; set; }
    }
}
