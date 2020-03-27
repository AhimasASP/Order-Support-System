using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OSS.WebApplication.Extensions;

namespace OSS.WebApplication.Configurations.Entity
{
    internal static class EntityConfiguration
    {
        internal static IServiceCollection RegisterEntity(this IServiceCollection service, IConfiguration configuration)
        {
            var dbConfig = configuration.GetDataBaseConfiguration();


            return service.AddDbContext<OssDbContext>(options => options
                .UseSqlServer(dbConfig.ConnectionString));
        }
    }
}
