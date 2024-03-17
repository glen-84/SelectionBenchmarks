namespace SelectionBenchmarks;

public sealed class AuthorType : ObjectType<Author>
{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(a => a.Id);

        descriptor.Field(a => a.Name);

        descriptor.Field(a => a.ImageUrl);

        descriptor.Field(a => a.RegisteredAt);
    }
}
