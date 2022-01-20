using Microsoft.EntityFrameworkCore;
using Contents.Application.Interfaces;
using Contents.Domain;
using Contents.Persistence.EntityTypeConfigurations;

namespace Contents.Persistence
{
    public class ContentsDbContext : DbContext, IContentsDbContext
    {
        public DbSet<File> Files { get; set; }
        public ContentsDbContext(DbContextOptions<ContentsDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContentConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
