using Microsoft.EntityFrameworkCore;

namespace SelectionBenchmarks;

[QueryType]
public static class ArticleQueries
{
    [UseSingleOrDefault]
    [UseProjection]
    public static IQueryable<Article> GetArticleWithProjection(long id, ApiDbContext dbContext)
    {
        return dbContext.Articles
            .Where(a => a.Id == id)
            .AsNoTracking();
    }

    [UseSingleOrDefault]
    public static IQueryable<Article> GetArticleWithoutProjection(long id, ApiDbContext dbContext)
    {
        return dbContext.Articles
            .Include(a => a.Author)
            .Where(a => a.Id == id)
            .AsNoTracking();
    }

    [UsePaging]
    [UseProjection]
    public static IQueryable<Article> GetArticlesWithProjection(ApiDbContext dbContext)
    {
        return dbContext.Articles
            .AsNoTracking();
    }

    [UsePaging]
    public static IQueryable<Article> GetArticlesWithoutProjection(ApiDbContext dbContext)
    {
        return dbContext.Articles
            .Include(a => a.Author)
            .AsNoTracking();
    }
}
