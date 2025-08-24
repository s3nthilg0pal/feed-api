using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Application.Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using OpenSearch.Client;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("FeedDb");

        builder.Services.AddDbContext<FeedContext>((options) =>
        {
            options.UseNpgsql(connectionString);

        });

        builder.Services.AddScoped<IFeedContext>(options => options.GetRequiredService<FeedContext>());
        builder.Services.AddSingleton(TimeProvider.System);

        var uri = builder.Configuration["OpenSearch:Uri"];
        var settings = new ConnectionSettings(new Uri(uri)).DefaultIndex("articles");
        builder.Services.AddSingleton<IOpenSearchClient>(new OpenSearchClient(settings));
    }
}