using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Data;
using Repository.Repositories.AboutCompanyRepository;
using Repository.Repositories.BlogsRepositories;
using Repository.Repositories.CaseStudyRepositories;
using Repository.Repositories.PlansRepositories;
using Repository.Repositories.SectionRepositories;
using Repository.Repositories.ServiceRepository;
using Repository.Services;

namespace Jotex
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
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<JotexDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("Default"),
                  x => x.MigrationsAssembly("Repository")));

            services.AddControllersWithViews();

            services.AddTransient<ISectionRepository, SectionRepository>();
            services.AddTransient<IAboutCompanyRepository, AboutCompanyRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IPlanRepository, PlanRepository>();
            services.AddTransient<ICaseStudyRepository, CaseStudyRepository>();
            services.AddTransient<IBlogRepository, BlogRepository>();


            services.AddTransient<ICloudinaryService, CloudinaryService>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
