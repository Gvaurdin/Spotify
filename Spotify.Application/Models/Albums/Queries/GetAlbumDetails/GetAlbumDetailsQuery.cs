using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Queries.GetAlbumDetails
{
    public class GetAlbumDetailsQuery: IRequest<AlbumDetailsViewModel>
    {
        public int Id { get; set; }
    }
}
