using March.Context;
using March.Interfaces;
using March.Middleware;
using March.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace March
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

            services.AddControllers();

            services.AddDbContext<StoreDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("MyDB"));
            });

            services.AddScoped<IProductServices, ProductServices>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiTest", Version = "v1" });

            });
            services.AddCors(); // Thêm Cors middleware
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiTest v1"));
            }



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(opt => {
                opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
                //
            });
            app.UseAuthentication();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
