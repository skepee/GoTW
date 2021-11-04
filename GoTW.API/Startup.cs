using GoTW.API.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GoTW.API
{
    public class Startup
    {
        readonly string GoTWAllowSpecificOrigins = "_goTWAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connString = Configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connString))
                connString = Configuration.GetConnectionString("local");

            services.AddDbContext<CommanderContext>(options => options.UseSqlServer(connString));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GoTW.API", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: GoTWAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("https://localhost:44305", "https://gotw.azurewebsites.net/")
                                             .AllowAnyHeader()
                                             .AllowAnyMethod(); ;
                                  });
            });

            if (!string.IsNullOrEmpty(connString))
                services.AddAzureAppConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GoTW.API v1"));
            }
            
            if (env.IsProduction())
                    app.UseAzureAppConfiguration();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(GoTWAllowSpecificOrigins);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
