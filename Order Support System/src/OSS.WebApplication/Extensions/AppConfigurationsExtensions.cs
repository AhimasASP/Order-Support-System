using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OSS.Domain.Common.Models.Api.Configs;

namespace OSS.WebApplication.Extensions
{
    internal static class AppConfigurationsExtensions
    {
        internal static IApplicationConfiguration GetApplicationConfiguration(this IConfiguration configuration)
            => configuration.GetConfiguration<IApplicationConfiguration, ApplicationConfiguration>(
                ConfigurationSectionNames.Application);
    }
}
