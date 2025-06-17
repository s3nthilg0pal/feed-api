using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Application.Common.Infrastructure;
using Microsoft.EntityFrameworkCore;

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
    }
}