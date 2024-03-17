using BenchmarkDotNet.Attributes;
using HotChocolate.Execution;

namespace SelectionBenchmarks;

// Use case: An article drop-down list, listing articles with their title (ID as value).
[MemoryDiagnoser]
public class BenchmarkSelectListData : BenchmarkBase
{
    [Benchmark]
    public async Task<string> SelectListDataWithProjection()
    {
        var queryRequestBuilder = new QueryRequestBuilder();

        queryRequestBuilder.SetQuery(
            """
            {
                articlesWithProjection {
                    nodes {
                        id
                        title
                    }
                }
            }
            """);

        var result = await this.Executor.ExecuteAsync(queryRequestBuilder.Create());

        return result.ExpectQueryResult().ToJson();
    }

    [Benchmark]
    public async Task<string> SelectListDataWithoutProjection()
    {
        var queryRequestBuilder = new QueryRequestBuilder();

        queryRequestBuilder.SetQuery(
            """
            {
                articlesWithoutProjection {
                    nodes {
                        id
                        title
                    }
                }
            }
            """);

        var result = await this.Executor.ExecuteAsync(queryRequestBuilder.Create());

        return result.ExpectQueryResult().ToJson();
    }
}
