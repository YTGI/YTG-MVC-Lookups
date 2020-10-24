// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: Main Startup class for MVC website

    Description: This is the main startup class that will load up the JSON serializer,
                 Dependency Injection objects, including the In Memory database

    Any place where there is non-boilerplate code that is of interest, I have added
    comments.

*/
// --------------------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using YTG.Lookups.Repository;
using YTG.Lookups.Repository.Context;
using YTG.Lookups.Services;

namespace YTG.MVC.Lookups
{

    /// <summary>
    /// Standard Startup Class
    /// Yasgar Technology Group, Inc. http://www.ytgi.com
    /// htts://jackyasgar.net
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// Contructor with DI configuration object
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the IConfiguration instance
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // I've found that using System.Text.Json is very problematic and reverted to Newtonsoft JSON
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                // This stops dates from being converted to UTC
                options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.RoundtripKind; // Dates as local, not UTC
            });

            // DBContext
            // The DB Context must be passed in by the Repository. If the service methods for this UI called a
            // REST web service, this would not be here, it would be in the REST API
            // Notice how it is using an InMemoryDatabase for this demo
            services.AddDbContext<LookupsDBContext>(options => options.UseInMemoryDatabase(databaseName: "Lookups").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            // Repository
            // Scoped implementation of the ILookupsRep repository
            services.AddScoped<ILookupsRep, LookupsRep>();

            // Service Layer
            // Scoped implementation of the ILookupsServices which would normally call a REST API,
            // but calls the repository directly for this demo app
            services.AddScoped<ILookupsServices, LookupsServices>();

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
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
