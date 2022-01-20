using System;
using MediatR;

namespace Contents.Application.Contents.Commands.DeleteCommand
{
    public class DeleteContentCommand :IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
