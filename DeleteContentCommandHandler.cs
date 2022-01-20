using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Contents.Application.Interfaces;
using Contents.Application.Common.Exceptions;
using Contents.Domain;

namespace Contents.Application.Contents.Commands.DeleteCommand
{
    public class DeleteContentCommandHandler
        : IRequestHandler<DeleteContentCommand>
    {
        private readonly IContentsDbContext _dbContext;
        public DeleteContentCommandHandler(IContentsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteContentCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Files
                    .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(File), request.Id);
            }

            _dbContext.Files.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
