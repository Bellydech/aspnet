using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mondial.DotNet.Library.Repositories.Interfaces;
using Mondial.DotNet.Library.Repositories.InMemory;
using Mondial.DotNet.Library.Context;
using Microsoft.EntityFrameworkCore;
using Mondial.DotNet.Library.Repositories.Db;

namespace Mondial.DotNet.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Injecter EF + Sqlite
            services.AddDbContext<ApplicationDbContext>(builder => 
                // Dans les params d'option, préciser que la db est Sqlite
                builder.UseSqlite(
                    // Préciser où trouver la chaine de connexion
                    Configuration.GetConnectionString("DefaultConnection"))
                );

            // Injecter le middleware ASP.NET Core MVC v2.2
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IPlayerRepository, DbContextPlayerRepository>();
            services.AddScoped<ITeamRepository, DbContextTeamRepository>();
            services.AddScoped<IContractRepository, DbContextContractRepository>();

            // Mapping du SeedData
            services.AddScoped<SeedData>();

            // Séparateur des nombres décimaux : "." et non pas ","
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture; 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
