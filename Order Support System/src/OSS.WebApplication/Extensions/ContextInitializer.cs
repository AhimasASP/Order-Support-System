using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using OSS.Domain.Interfaces.Services;

namespace OSS.WebApplication.Extensions
{
    public static class ContextInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var seedService =  (ISeedService)serviceProvider.GetService(typeof(ISeedService));

            await seedService.SeedRoles();
            await seedService.SeedUsers();
            await seedService.SeedItems();
        }
        
    }
}