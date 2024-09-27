using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Commands.UpdateSong
{
    public class UpdateSongCommand: IRequest
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
