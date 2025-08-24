using MediatR;
using OpenSearch.Client;

namespace Application.Articles.SearchArticles;

public record SearchArticlesQuery(string Term) : IRequest<IEnumerable<ArticleSearchDocument>>;

public class SearchArticlesQueryHandler : IRequestHandler<SearchArticlesQuery, IEnumerable<ArticleSearchDocument>>
{
    private readonly IOpenSearchClient _client;

    public SearchArticlesQueryHandler(IOpenSearchClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<ArticleSearchDocument>> Handle(SearchArticlesQuery request, CancellationToken cancellationToken)
    {
        var response = await _client.SearchAsync<ArticleSearchDocument>(s => s
            .Query(q => q
                .MultiMatch(m => m
                    .Fields(f => f
                        .Field(p => p.Title)
                        .Field(p => p.Content)
                        .Field(p => p.Text)
                        .Field(p => p.Link)
                    )
                    .Query(request.Term)
                )
            ), cancellationToken);

        return response.Documents;
    }
}

