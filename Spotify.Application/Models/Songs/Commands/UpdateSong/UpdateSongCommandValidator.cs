using FluentValidation;
using Spotify.Application.Models.Songs.Commands.CreateSong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Songs.Commands.UpdateSong
{
    public class UpdateSongCommandValidator : AbstractValidator<UpdateSongCommand>
    {
        public UpdateSongCommandValidator()
        {
            RuleFor(updateSongCommand => updateSongCommand.Title)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
