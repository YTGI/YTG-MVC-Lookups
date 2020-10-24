// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: Main program entry point for this web site

    Description: 

*/
// --------------------------------------------------------------------------------

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;

using YTG.Lookups.Repository.Context;

namespace YTG.MVC.Lookups
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Get the IWebHost which will host this application.
            IHost host = CreateHostBuilder(args).Build();

            //2. Find the service layer within our scope.
            using (IServiceScope scope = host.Services.CreateScope())
            {
                //3. Get the instance of LookupsDBContext in our services layer
                IServiceProvider services = scope.ServiceProvider;
                LookupsDBContext context = services.GetRequiredService<LookupsDBContext>();

                //4. Call the DataGenerator to create sample data
                LookupsGenerator.Initialize(services);
            }

            //Continue to run the application
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
