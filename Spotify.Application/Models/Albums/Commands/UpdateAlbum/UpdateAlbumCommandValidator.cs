using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommandValidator: AbstractValidator<UpdateAlbumCommand>
    {
        public UpdateAlbumCommandValidator()
        {
            RuleFor(updateAlbumCommand => updateAlbumCommand.Title)
                .NotEmpty()
                .MaximumLength(200);
            RuleFor(updateAlbumCommand => updateAlbumCommand.Description)
                .MaximumLength(300);
        }
    }
}
