using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Genres.Commands.CreateGenreCommand
{
    public class CreateGenreCommand: IRequest<int>
    {
        public required string Title { get; set; }
    }
}
