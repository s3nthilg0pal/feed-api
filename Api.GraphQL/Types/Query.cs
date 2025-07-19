using Application.Articles.GetAllArticles;
using MediatR;

namespace Api.GraphQL.Types
{
    public class Query
    {
        private readonly IMediator _mediator;

        public Query(IMediator mediator)
        {
            _mediator = mediator;
        }

        [GraphQLDescription("Get all articles")]
        public async Task<IEnumerable<ArticleDto>> GetAllArticlesAsync()
        {
            var query = new GetAllArticlesQuery();
            var articles = await _mediator.Send(query);
            return articles;
        }
    }
}
