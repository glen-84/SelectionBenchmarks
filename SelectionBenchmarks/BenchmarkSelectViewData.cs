using BenchmarkDotNet.Attributes;
using HotChocolate.Execution;

namespace SelectionBenchmarks;

// Use case: An article view page, displaying a single article.
[MemoryDiagnoser]
public class BenchmarkSelectViewData : BenchmarkBase
{
    [Benchmark]
    public async Task<string> SelectViewDataWithProjection()
    {
        var queryRequestBuilder = new QueryRequestBuilder();

        queryRequestBuilder.SetQuery(
            """
            {
                articleWithProjection(id: 1000001) {
                    id
                    author {
                        id
                        name
                        imageUrl
                    }
                    title
                    content
                    imageUrl
                    publishedAt
                    commentCount
                }
            }
            """);

        var result = await this.Executor.ExecuteAsync(queryRequestBuilder.Create());

        return result.ExpectQueryResult().ToJson();
    }

    [Benchmark]
    public async Task<string> SelectViewDataWithoutProjection()
    {
        var queryRequestBuilder = new QueryRequestBuilder();

        queryRequestBuilder.SetQuery(
            """
            {
                articleWithoutProjection(id: 1000001) {
                    id
                    author {
                        id
                        name
                        imageUrl
                    }
                    title
                    content
                    imageUrl
                    publishedAt
                    commentCount
                }
            }
            """);

        var result = await this.Executor.ExecuteAsync(queryRequestBuilder.Create());

        return result.ExpectQueryResult().ToJson();
    }
}
