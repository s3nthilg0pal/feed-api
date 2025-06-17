using Api.Infrastructure;
using Application.Articles.GetAllArticles;
using Application.Common.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Api.Endpoints;

public class Feeds : EndpointGroupBase
{

    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllArticles, pattern:"/articles");
    }

    public async Task<Ok<IEnumerable<ArticleDto>>> GetAllArticles(IMediator mediator)
    {
        var request = new GetAllArticlesQuery();
        var articles = await mediator.Send(request);
        return TypedResults.Ok(articles);
    }
}