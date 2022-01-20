using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Contents.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Contents.Application.Common.Exceptions;
using Contents.Domain;

namespace Contents.Application.Contents.Queries.GetContentDescriptions
{
    public class GetContentDescriptionsQueryHandler
        : IRequestHandler<GetContentDescriptionsQuery, ContentDescriptionsVm>
    {
        private readonly IContentsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetContentDescriptionsQueryHandler(IContentsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<ContentDescriptionsVm> Handle(GetContentDescriptionsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Files
                .FirstOrDefaultAsync(content =>
                content.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(File), request.Id);
            }
            return _mapper.Map<ContentDescriptionsVm>(entity);
        }
    }
}
