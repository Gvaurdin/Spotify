using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandValidator: AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator() 
        {
            RuleFor(createGroupCommand => createGroupCommand.Title)
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(createGroupCommand => createGroupCommand.Description)
                .MaximumLength(300);
        }
    }
}
