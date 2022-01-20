using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Contents.Domain;
using Contents.Application.Interfaces;

namespace Contents.Application.Contents.Commands.AddContent
{
    class AddContentCommandHandler
        :IRequestHandler<AddContentCommand, Guid>
    {
        private readonly IContentsDbContext _dbContext;
        public AddContentCommandHandler(IContentsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(AddContentCommand request,
            CancellationToken cancellationToken)
        {
            var content = new File
            {
                UserId = request.UserId,
                Id = Guid.NewGuid(),
                Title = request.Title,
                Format = request.Format,
                Created = DateTime.Now,
                Updated = null,
                Description = request.Description
            };
            await _dbContext.Files.AddAsync(content, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return content.Id;
        } 
    }
}
