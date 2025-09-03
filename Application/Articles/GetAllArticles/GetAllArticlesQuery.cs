using Application.Common.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Articles.GetAllArticles;

public class GetAllArticlesQuery : IRequest<IEnumerable<ArticleDto>>
{
    
}

public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, IEnumerable<ArticleDto>>
{
    private readonly IFeedContext _feedContext;

    public GetAllArticlesQueryHandler(IFeedContext feedContext)
    {
        _feedContext = feedContext;
    }
    public async Task<IEnumerable<ArticleDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await _feedContext.Articles
            .Where(a => a.Categories != "news" || a.Categories != "awesome")
            .Where(a => !string.IsNullOrEmpty(a.Title))
            .OrderByDescending(a => a.CreatedAt)
            .Select(a => new ArticleDto()
        {
            Content = a.Content,
            Link = a.Link,
            PublishedAt = a.PublishedParsed.Value.ToString("yyyy-MM-dd"),
            Title = a.Title,
            Tags = a.Categories.Split(',', StringSplitOptions.RemoveEmptyEntries),
            Text = a.Text,
            GeneratedOn    = DateTime.Now.ToString("yyyy-MM-dd")
        }).Take(100).ToArrayAsync(cancellationToken);

        return articles;
    }
}