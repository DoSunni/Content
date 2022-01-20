using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Contents.Application.Interfaces;
using Contents.Application.Common.Exceptions;
using Contents.Domain;

namespace Contents.Application.Contents.Commands.UpdateContent
{
    public class UpdateContentCommandHandler
        : IRequestHandler<UpdateContentCommand>
    {
        private readonly IContentsDbContext _dbContext;
        public UpdateContentCommandHandler(IContentsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateContentCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Files.FirstOrDefaultAsync(content =>
                    content.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(File), request.Id);
            }

            entity.Title = request.Title;
            entity.Updated = DateTime.Now;
            entity.Format = request.Format;
            entity.Description = request.Description;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
