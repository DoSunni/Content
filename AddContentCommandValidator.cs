using System;
using FluentValidation;

namespace Contents.Application.Contents.Commands.AddContent
{
    public class AddContentCommandValidator : AbstractValidator<AddContentCommand>
    {
        public AddContentCommandValidator()
        {
            RuleFor(addContentCommand =>
                addContentCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(addContentCommand =>
                addContentCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
