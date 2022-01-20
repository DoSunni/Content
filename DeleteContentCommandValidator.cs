using System;
using FluentValidation;

namespace Contents.Application.Contents.Commands.DeleteCommand
{
    public class DeleteContentCommandValidator : AbstractValidator<DeleteContentCommand>
    {
        public DeleteContentCommandValidator()
        {
            RuleFor(deleteContentCommand =>
                deleteContentCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(deleteContentCommand =>
                deleteContentCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
