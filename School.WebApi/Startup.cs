using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using School.DataAccess;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;

namespace School.WebApi
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

            services.AddDbContext(Configuration);
            services.AddUnitOfWork();
            services.AddQueryProcessors();

            Assembly assembly = AppDomain.CurrentDomain.Load("School.WebApi");
            services.AddAutoMapper(assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            InitDatabase(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitDatabase(IApplicationBuilder app)
        {
            IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            SchoolDBContext schoolDBContext = serviceScope.ServiceProvider.GetService<SchoolDBContext>();
            schoolDBContext.Database.Migrate();
        }
    }
}
