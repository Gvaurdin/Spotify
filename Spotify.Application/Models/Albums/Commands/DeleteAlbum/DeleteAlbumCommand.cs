using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumCommand: IRequest
    {
        public int Id { get; set; }
    }
}
