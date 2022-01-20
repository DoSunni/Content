using System;
using FluentValidation;

namespace Contents.Application.Contents.Queries.GetContentDescriptions
{
    public class GetContentDescriptionQueryValidator : AbstractValidator<GetContentDescriptionsQuery>
    {
        public GetContentDescriptionQueryValidator()
        {
            RuleFor(content =>
                content.UserId).NotEqual(Guid.Empty);
            RuleFor(content =>
                content.Id).NotEqual(Guid.Empty);
        }

    }
}
