using Application.Common.Infrastructure;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using OpenSearch.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);
builder.AddInfrastructureServices();

using var host = builder.Build();
using var scope = host.Services.CreateScope();

var context = scope.ServiceProvider.GetRequiredService<IFeedContext>();
var client = scope.ServiceProvider.GetRequiredService<IOpenSearchClient>();

var articles = await context.Articles.ToListAsync();
await client.IndexManyAsync(articles, "articles");

