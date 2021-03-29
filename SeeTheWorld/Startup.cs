using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using SeeTheWorld.Contexts;
using SeeTheWorld.Services;

namespace SeeTheWorld
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var baseUrlConfig = Configuration["AppConfig:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrlConfig))
            {
                BaseUrl = string.Empty;
            }
            else if (!baseUrlConfig.StartsWith('/'))
            {
                BaseUrl = "/" + baseUrlConfig;
            }
        }

        public IConfiguration Configuration { get; }
        public string BaseUrl { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SeeTheWorldContext>(opt =>
                opt.UseSqlite(
                    Configuration.GetConnectionString("SqLite"))
                );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddLogging();
            services.AddScoped<IPictureService, PictureService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                // 更改请求的URL
                c.AddServer(new OpenApiServer { Url = BaseUrl });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SeeTheWorld", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(
                opt => opt.RouteTemplate = "/docs/{documentName}/swagger.json"
            );

            app.UseSwaggerUI(opt =>
            {
                opt.RoutePrefix = "docs";
                opt.SwaggerEndpoint("v1/swagger.json", "SeeTheWorld v1");
            });

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
