using BenchmarkDotNet.Attributes;
using HotChocolate.Execution;

namespace SelectionBenchmarks;

[MemoryDiagnoser]
public class BenchmarkSelectAllFields : BenchmarkBase
{
    [Benchmark]
    public async Task<string> SelectAllFieldsWithProjection()
    {
        var queryRequestBuilder = new QueryRequestBuilder();

        queryRequestBuilder.SetQuery(
            """
            {
                articlesWithProjection {
                    nodes {
                        id
                        author {
                            id
                            name
                            imageUrl
                            registeredAt
                        }
                        title
                        content
                        excerpt
                        imageUrl
                        status
                        createdAt
                        updatedAt
                        publishedAt
                        commentCount
                    }
                }
            }
            """);

        var result = await this.Executor.ExecuteAsync(queryRequestBuilder.Create());

        return result.ExpectQueryResult().ToJson();
    }

    [Benchmark]
    public async Task<string> SelectAllFieldsWithoutProjection()
    {
        var queryRequestBuilder = new QueryRequestBuilder();

        queryRequestBuilder.SetQuery(
            """
            {
                articlesWithoutProjection {
                    nodes {
                        id
                        author {
                            id
                            name
                            imageUrl
                            registeredAt
                        }
                        title
                        content
                        excerpt
                        imageUrl
                        status
                        createdAt
                        updatedAt
                        publishedAt
                        commentCount
                    }
                }
            }
            """);

        var result = await this.Executor.ExecuteAsync(queryRequestBuilder.Create());

        return result.ExpectQueryResult().ToJson();
    }
}
