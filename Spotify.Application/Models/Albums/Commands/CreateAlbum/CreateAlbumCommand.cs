using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommand: IRequest<int>
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
