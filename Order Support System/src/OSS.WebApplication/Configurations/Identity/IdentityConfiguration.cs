using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OSS.Common;
using OSS.Domain.Common.Models.DbModels;
using OSS.WebApplication.Configurations.Entity;

namespace OSS.WebApplication.Configurations.Identity
{
    internal static class IdentityConfiguration
    {
        internal static IServiceCollection RegisterIdentity(this IServiceCollection service)
        {
            service.AddIdentity<UserDbModel, IdentityRole>(options => options
                    .User.RequireUniqueEmail = false)
                .AddEntityFrameworkStores<OssDbContext>()
                .AddDefaultTokenProviders();
            return service;
        }

    }
}
