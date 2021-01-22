using Eml.ConfigParser.Helpers;
using Eml.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Extensions
{
    public static class StartupExtensions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration); // Register IConfiguration instance. Note: This is for manual registration of IConfiguration, Asp.Net will automatically do this for you. 
            services.Scan(scan => scan
                .FromApplicationDependencies()

                // Register ConfigParsers
                .AddClasses(classes => classes.AssignableTo<IConfigParserBase>())
                .AsSelfWithInterfaces()
                .WithScopedLifetime()

                // IDiDiscoverableTransient
                .AddClasses(classes => classes.AssignableTo(typeof(IDiDiscoverableTransient)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            );
        }

        public static IConfiguration GetConfiguration(this string currentEnvironment, string customConfigJsonFile)
        {
            var configuration = ConfigBuilder.GetConfiguration(currentEnvironment)
                .AddJsonFile(customConfigJsonFile)                        // <- Will search for files in the current directory. See Getting Started on how to CopyToOutputDirectory.
                .Build();

            return configuration;
        }
    }
}