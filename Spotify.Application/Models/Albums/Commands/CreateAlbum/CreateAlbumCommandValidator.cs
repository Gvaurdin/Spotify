using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandValidator: AbstractValidator<CreateAlbumCommand>
    {
        public CreateAlbumCommandValidator()
        {
            RuleFor(createAlbumCommand => createAlbumCommand.Title)
                .NotEmpty()
                .MaximumLength(200);
            RuleFor(createAlbumCommand => createAlbumCommand.Description)
                .MaximumLength(300);
        }
    }
}
