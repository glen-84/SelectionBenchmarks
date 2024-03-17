using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SelectionBenchmarks;

public sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        // Properties

        builder
            .Property(a => a.Name)
            .HasMaxLength(100);

        builder
            .Property(a => a.ImageUrl)
            .HasMaxLength(255);
    }
}
