using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Commands.DeleteSong
{
    public class DeleteSongCommand: IRequest
    {
        public int Id { get; set; }
    }
}
