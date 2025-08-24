using Api.Infrastructure;
using Application.Articles.SearchArticles;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Endpoints;

public class Search : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(Get);
    }

    public async Task<Ok<IEnumerable<ArticleSearchDocument>>> Get(string term, IMediator mediator)
    {
        var request = new SearchArticlesQuery(term);
        var articles = await mediator.Send(request);
        return TypedResults.Ok(articles);
    }
}

