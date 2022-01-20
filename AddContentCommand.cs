using System;
using MediatR;

namespace Contents.Application.Contents.Commands.AddContent
{
    public class AddContentCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }
    }
}
