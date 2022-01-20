using System;
using MediatR;

namespace Contents.Application.Contents.Queries.GetContentDescriptions
{
    public class GetContentDescriptionsQuery : IRequest<ContentDescriptionsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
