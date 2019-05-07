using AutoMapper;
using DotNetPaging.AspNetCore.Models;
using DotNetPaging.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetPaging.AspNetCore
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
            services.AddDbContext<DotNetPagingDbContext>(options =>
                    options.UseSqlServer(
                                            Configuration.GetConnectionString("DefaultConnection"), 
                                            sqlServerOptions => sqlServerOptions.UseRowNumberForPaging()) //nedded only for SQL Server versions prior to SQL Server 2012
                                        );

            services.AddHttpContextAccessor();
            services.AddAutoMapper(GetType().Assembly);

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "defaultPaged",
                        template: "{controller=Home}/{action=Index}/page/{page}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
