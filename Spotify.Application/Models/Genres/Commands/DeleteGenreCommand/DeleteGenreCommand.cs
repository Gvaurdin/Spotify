using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Genres.Commands.DeleteGenreCommand
{
    public class DeleteGenreCommand: IRequest
    {
        public int Id { get; set; }
    }
}
