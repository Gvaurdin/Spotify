using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommand: IRequest
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
