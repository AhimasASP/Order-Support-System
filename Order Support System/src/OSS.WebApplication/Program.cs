using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Interfaces.Services;
using OSS.Domain.Logic.Services;
using OSS.WebApplication.Configurations.Entity;
using OSS.WebApplication.Extensions;

namespace OSS.WebApplication
{
    public class Program
    {
       public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {

                //var services = scope.ServiceProvider;
                //var context = services.GetRequiredService<OssDbContext>();
                //try
                //{
                //    var userManager = services.GetRequiredService<UserManager<UserDbModel>>();
                //    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                //    var tmp = services.GetRequiredService<UserService>();
                //    Initializer initializer = new Initializer();
                //    await initializer.RoleInitializer(context, roleManager);
                //    await initializer.UserInitializer(context, userManager);
                //    await initializer.ItemInitializer(context);
                //}
                //catch (Exception e)
                //{
                //    var logger = services.GetRequiredService<ILogger<Program>>();
                //    logger.LogError(e, "An error occurred while seeding the database.");
                //}

                var services = scope.ServiceProvider;
                await ContextInitializer.Initialize(services);
            }
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
