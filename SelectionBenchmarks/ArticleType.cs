namespace SelectionBenchmarks;

public sealed class ArticleType : ObjectType<Article>
{
    protected override void Configure(IObjectTypeDescriptor<Article> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(a => a.Id);

        descriptor.Field(a => a.Author);

        descriptor.Field(a => a.Title);

        descriptor.Field(a => a.Content);

        descriptor.Field(a => a.Excerpt);

        descriptor.Field(a => a.ImageUrl);

        descriptor.Field(a => a.Status);

        descriptor.Field(a => a.CreatedAt);

        descriptor.Field(a => a.UpdatedAt);

        descriptor.Field(a => a.PublishedAt);

        descriptor.Field(a => a.CommentCount);
    }
}
