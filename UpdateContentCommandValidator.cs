using System;
using FluentValidation;

namespace Contents.Application.Contents.Commands.UpdateContent
{
    public class UpdateContentCommandValidator : AbstractValidator<UpdateContentCommand>
    {
        public UpdateContentCommandValidator()
        {
            RuleFor(updateContentCommand =>
                updateContentCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(updateContentCommand =>
                updateContentCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateContentCommand =>
                updateContentCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
