using BenchmarkDotNet.Attributes;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SelectionBenchmarks;

public abstract class BenchmarkBase
{
    protected IRequestExecutor Executor = null!;

    [GlobalSetup]
    public async Task GlobalSetup()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddDbContext<ApiDbContext>(options =>
        {
            options.UseNpgsql(
                "Host=127.0.0.1;Username=selection_benchmarks;Password=selection_benchmarks;" +
                "Database=selection_benchmarks");
        });

        this.Executor = await serviceCollection
            .AddGraphQL()
            .InitializeOnStartup()
            .AddProjections()
            .AddTypes()
            .BuildRequestExecutorAsync();

        var dbContext = this.Executor.Services.GetApplicationService<ApiDbContext>();
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();
    }
}
