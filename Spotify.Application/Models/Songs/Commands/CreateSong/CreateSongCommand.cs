using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Commands.CreateSong
{
    public class CreateSongCommand: IRequest<int>
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
