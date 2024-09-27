using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Genres.Commands.UpdateGenreCommand
{
    public class UpdateGenreCommand: IRequest
    {
        public int Id { get; set; }
        public required string Title { get; set; }
    }
}
