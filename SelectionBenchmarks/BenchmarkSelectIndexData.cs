using BenchmarkDotNet.Attributes;
using HotChocolate.Execution;

namespace SelectionBenchmarks;

// Use case: An article index page, listing articles with their title/image/publish date/URL.
[MemoryDiagnoser]
public class BenchmarkSelectIndexData : BenchmarkBase
{
    [Benchmark]
    public async Task<string> SelectIndexDataWithProjection()
    {
        var queryRequestBuilder = new QueryRequestBuilder();

        queryRequestBuilder.SetQuery(
            """
            {
                articlesWithProjection {
                    nodes {
                        id
                        title
                        imageUrl
                        publishedAt
                    }
                }
            }
            """);

        var result = await this.Executor.ExecuteAsync(queryRequestBuilder.Create());

        return result.ExpectQueryResult().ToJson();
    }

    [Benchmark]
    public async Task<string> SelectIndexDataWithoutProjection()
    {
        var queryRequestBuilder = new QueryRequestBuilder();

        queryRequestBuilder.SetQuery(
            """
            {
                articlesWithoutProjection {
                    nodes {
                        id
                        title
                        imageUrl
                        publishedAt
                    }
                }
            }
            """);

        var result = await this.Executor.ExecuteAsync(queryRequestBuilder.Create());

        return result.ExpectQueryResult().ToJson();
    }
}
