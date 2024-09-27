using FluentValidation;
using Spotify.Application.Models.Groups.Commands.CreateGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
    {
        public UpdateGroupCommandValidator()
        {
            RuleFor(updateGroupCommand => updateGroupCommand.Title)
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(updateGroupCommand => updateGroupCommand.Description)
                .MaximumLength(300);
        }
    }
}
