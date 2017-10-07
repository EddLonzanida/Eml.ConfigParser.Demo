using System.IO;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses
{
    public abstract class IntegrationTestBase 
    {
        protected readonly IConfiguration Configuration;
        protected IntegrationTestBase()
        {
            Configuration = GetConfiguration();
        }

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
