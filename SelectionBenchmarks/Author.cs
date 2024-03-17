namespace SelectionBenchmarks;

public sealed class Author
{
    public long Id { get; private set; }

    public string Name { get; private set; } = null!;

    public Uri ImageUrl { get; private set; } = null!;

    public DateTimeOffset RegisteredAt { get; private set; }

    private Author() { }

    public static Author Register(
        long id,
        string name,
        string imageUrl)
    {
        return new Author()
        {
            Id = id,
            Name = name,
            ImageUrl = new Uri(imageUrl),
            RegisteredAt = DateTimeOffset.UtcNow
        };
    }
}
