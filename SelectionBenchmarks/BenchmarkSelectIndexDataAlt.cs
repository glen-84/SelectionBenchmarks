using BenchmarkDotNet.Attributes;
using HotChocolate.Execution;

namespace SelectionBenchmarks;

// Use case: An article index page, listing articles with their title/excerpt/image/publish date/
// author details/comment count/URL.
[MemoryDiagnoser]
public class BenchmarkSelectIndexDataAlt : BenchmarkBase
{
    [Benchmark]
    public async Task<string> SelectIndexDataAltWithProjection()
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
                        }
                        title
                        excerpt
                        imageUrl
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
    public async Task<string> SelectIndexDataAltWithoutProjection()
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
                        }
                        title
                        excerpt
                        imageUrl
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
