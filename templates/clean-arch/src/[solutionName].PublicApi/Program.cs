using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using [solutionName].Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using [solutionName].Persistence;

namespace [solutionName].PublicApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope())
            {
                var dbContext = (ApplicationDbContext)scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
                dbContext.Database.Migrate();
                ApplicationDbInitializer.Initialize(dbContext);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
