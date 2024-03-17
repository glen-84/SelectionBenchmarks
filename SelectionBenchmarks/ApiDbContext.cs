using System.Reflection;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace SelectionBenchmarks;

public sealed class ApiDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Article> Articles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        var faker = new Faker() { Random = new Randomizer(0) };

        foreach (var i in Enumerable.Range(0, 10))
        {
            var person = new Person();

            modelBuilder
                .Entity<Author>()
                .HasData(Author.Register(
                    id: 1_000_000 + i,
                    name: person.FullName,
                    imageUrl: person.Avatar));

            modelBuilder
                .Entity<Article>()
                .HasData(Article.Create(
                    id: 1_000_000 + i,
                    authorId: 1_000_000 + i,
                    title: faker.Lorem.Sentence(2, 5).TrimEnd('.'),
                    content: faker.Lorem.Paragraphs(10),
                    excerpt: faker.Lorem.Sentence(10, 5).TrimEnd('.'),
                    imageUrl: faker.Image.PlaceholderUrl(1920, 1080)));
        }

        base.OnModelCreating(modelBuilder);
    }
}
