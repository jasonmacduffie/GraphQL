using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Logging.Schema;
using Logging.Services;
using Logging.Models;

namespace Server
{
    public class Startup
    {

        public Startup(IHostingEnvironment environment)
        {
            Environment = environment;
        }

        public IHostingEnvironment Environment { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IService<Broker>, BrokerService>();
            services.AddSingleton<IService<BusinessFunction>, BusinessFunctionService>();
            services.AddSingleton<IService<Message>, MessageService>();
            services.AddTransient<BrokerType>();
            services.AddTransient<BusinessFunctionType>();
            services.AddTransient<MessageType>();
            services.AddTransient<MessageSchema>();
            services.AddTransient<Query>();
            services.AddSingleton<IDependencyResolver>(c => new FuncDependencyResolver(type => c.GetRequiredService(type)));
            services.AddGraphQL(options=> {
                options.EnableMetrics = true;
                options.ExposeExceptions = Environment.IsDevelopment();
            })
            .AddWebSockets()
            .AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
                 
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseGraphQLWebSockets<MessageSchema>("/graphql");
            app.UseGraphQL<MessageSchema>("/graphql");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()
            {
                Path = "/ui/playground"
            });
            app.UseGraphiQLServer(new GraphiQLOptions
            {
                GraphiQLPath = "/ui/graphiql",
                GraphQLEndPoint = "/graphql"
            });
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
                Path = "/ui/voyager"
            });
        }
    }
}
