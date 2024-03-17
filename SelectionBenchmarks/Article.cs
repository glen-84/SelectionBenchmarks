namespace SelectionBenchmarks;

public sealed class Article
{
    public long Id { get; private set; }

    public long AuthorId { get; private set; }

    public Author Author { get; private set; } = null!;

    public string Title { get; private set; } = null!;

    public string Content { get; private set; } = null!;

    public string Excerpt { get; private set; } = null!;

    public Uri ImageUrl { get; private set; } = null!;

    public ArticleStatus Status { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public DateTimeOffset? PublishedAt { get; private set; }

    public int CommentCount { get; private set; }

    private Article() { }

    public static Article Create(
        long id,
        long authorId,
        string title,
        string content,
        string excerpt,
        string imageUrl)
    {
        return new Article()
        {
            Id = id,
            AuthorId = authorId,
            Title = title,
            Content = content,
            Excerpt = excerpt,
            ImageUrl = new Uri(imageUrl),
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow
        };
    }

    public void Publish()
    {
        this.PublishedAt = DateTimeOffset.UtcNow;
    }
}
