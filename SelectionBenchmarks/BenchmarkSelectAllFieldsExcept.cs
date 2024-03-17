using BenchmarkDotNet.Attributes;
using HotChocolate.Execution;

namespace SelectionBenchmarks;

// Use case: Remove text fields to reduce performance impact.
[MemoryDiagnoser]
public class BenchmarkSelectAllFieldsExcept : BenchmarkBase
{
    [Benchmark]
    public async Task<string> SelectAllFieldsExceptContent()
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
    public async Task<string> SelectAllFieldsExceptContentAndExcerpt()
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
