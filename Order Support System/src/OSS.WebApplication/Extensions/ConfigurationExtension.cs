using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace OSS.WebApplication.Extensions
{
    public static class ConfigurationExtension
    {
        public static TConfiguration GetConfiguration<TConfiguration, TConfigurationImplementation>(
            this IConfiguration configuration,
            string sectionName)
            where TConfigurationImplementation : TConfiguration
            => configuration
                .GetSection(sectionName)
                .Get<TConfigurationImplementation>();
    }
}
