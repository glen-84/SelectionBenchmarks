using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SelectionBenchmarks;

public sealed class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        // Properties

        builder
            .Property(a => a.Title)
            .HasMaxLength(100);

        builder
            .Property(a => a.Content)
            .HasMaxLength(100_000);

        builder
            .Property(a => a.Excerpt)
            .HasMaxLength(160);

        builder
            .Property(a => a.ImageUrl)
            .HasMaxLength(255);
    }
}
