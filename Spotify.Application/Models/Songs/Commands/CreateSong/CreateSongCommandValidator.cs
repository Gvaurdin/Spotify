using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Commands.CreateSong
{
    public class CreateSongCommandValidator: AbstractValidator<CreateSongCommand>
    {
        public CreateSongCommandValidator()
        {
            RuleFor(createSongCommand => createSongCommand.Title)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
