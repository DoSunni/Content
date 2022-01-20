using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Contents.Domain;

namespace Contents.Persistence.EntityTypeConfigurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<File> 
    {
        public void Configure(EntityTypeBuilder<File>builder)
        {
            builder.HasKey(file => file.Id);
            builder.HasIndex(file => file.Id).IsUnique();
            builder.Property(file => file.Title).HasMaxLength(250);
        }
    }
}
