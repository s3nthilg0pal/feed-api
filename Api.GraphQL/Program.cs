
using Api.GraphQL.Types;
using Application;
using Infrastructure;

namespace Api.GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(op =>
            {
                op.AddPolicy("Allow" , (policy) =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            builder.AddInfrastructureServices();
            builder.AddApplicationServices();

            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>();
            
            var app = builder.Build();
            app.UseCors();
            app.MapGraphQL();

            app.UseHttpsRedirection();


            app.Run();
        }
    }
}
