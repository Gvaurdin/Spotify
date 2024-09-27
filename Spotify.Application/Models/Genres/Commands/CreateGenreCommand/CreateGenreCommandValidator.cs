using FluentValidation;
using Spotify.Application.Models.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Genres.Commands.CreateGenreCommand
{
    public class CreateGenreCommandValidator: AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator() 
        {
            RuleFor(createGenreCommand => createGenreCommand.Title)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
