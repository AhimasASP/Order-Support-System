using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OSS.WebApplication.Extensions;

namespace OSS.WebApplication.Swagger
{
    internal static class SwaggerConfiguration
    {
        
        internal static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder application,
            IConfiguration configuration)
        {
            var appConfig = configuration.GetApplicationConfiguration();
            return application
                .UseSwagger()
                .UseSwaggerUI(_ => _.SwaggerEndpoint(
                    string.Format(
                        appConfig.SwaggerUrlTemplate,
                        appConfig.Version),
                    appConfig.Name));
        }

        internal static IServiceCollection RegisterSwagger(this IServiceCollection service,
            IConfiguration configuration)
        {
            var appConfig = configuration.GetApplicationConfiguration();

            service.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName);
                options.SwaggerDoc(appConfig.Version,
                    new OpenApiInfo {Title = appConfig.Name, Version = appConfig.Version});
            });
                
            return service;
        }
    }
}
