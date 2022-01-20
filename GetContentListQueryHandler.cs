using System.Linq;
using AutoMapper.QueryableExtensions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Contents.Application.Interfaces;

namespace Contents.Application.Contents.Queries.GetContentList
{
    public class GetContentListQueryHandler
        : IRequestHandler<GetContentListQuery, ContentListVm>
    {
        private readonly IContentsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetContentListQueryHandler(IContentsDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ContentListVm> Handle(GetContentListQuery request,
            CancellationToken cancellationToken)
        {
            var contentsQuery = await _dbContext.Files
                .Where(content => content.UserId == request.UserId)
                .ProjectTo<ContentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ContentListVm { Files = contentsQuery };
        }
    }
}
