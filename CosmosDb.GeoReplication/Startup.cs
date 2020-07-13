using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CosmosDb.GeoReplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var accountEndpoint = Configuration.GetValue<string>("ConnectionString:AccountEndpoint");
            var accountKey= Configuration.GetValue<string>("ConnectionString:AccountKey");
            var dbName= Configuration.GetValue<string>("ConnectionString:DatabaseName");
            var region = Configuration.GetValue<string>("ApiServerRegion"); 
            //.Bind("ConnectionString:AccountEndpoint");
            services.AddDbContext<ProfileContext>(x => x.UseCosmos(accountEndpoint, accountKey, dbName
                ,cosmosOptionsAction=>cosmosOptionsAction.Region(region)));
            services.AddControllers();
            services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
