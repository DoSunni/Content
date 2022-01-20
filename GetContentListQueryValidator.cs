using System;
using FluentValidation;

namespace Contents.Application.Contents.Queries.GetContentList
{
    public class GetContentListQueryValidator : AbstractValidator<GetContentListQuery>
    {
        public GetContentListQueryValidator ()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
