using System;
using MediatR;

namespace Contents.Application.Contents.Queries.GetContentList
{
    public class GetContentListQuery : IRequest<ContentListVm>
    {
        public Guid UserId { get; set; }
    }
}
