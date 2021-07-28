using System;
using System.Collections.Generic;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Jido.Infrastructure.Couchbase;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Jido
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
            services.AddFluentValidation();
            services.AddDomain();
            services.AddInfrastructure();

            // Couchbase
            // from https://blog.couchbase.com/dependency-injection-aspnet-couchbase/
            services.AddCouchbase(client =>
            {
                client.Servers = new List<Uri> {new Uri("http://localhost:8091")};
                client.UseSsl = false;
                client.Username = "Administrator";
                client.Password = "administrator";
            });
            services.AddCouchbaseBucket<ITestBucketProvider>("TestBucket");

            services.AddMvcCore()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
