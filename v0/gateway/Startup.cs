using System;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace Demo.Gateway
{
    public class Startup
    {
        public const string PublishBook = "publishBook";

        public Uri SubscriptionServiceUrl = new Uri("http://localhost:56963/graphql/");
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        { 
           

            services.AddHttpClient(PublishBook, c => c.BaseAddress = SubscriptionServiceUrl);

            services
                .AddGraphQLServer()
                .AddRemoteSchema(PublishBook)
                .AddInMemorySubscriptions();// Application In-Memory storage used by the GraphQL Subscriptions
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseWebSockets();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

        }
    }
}
