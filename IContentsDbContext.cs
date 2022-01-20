using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contents.Domain;

namespace Contents.Application.Interfaces
{
    public interface IContentsDbContext
    {
        DbSet<File> Files { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
