using Eml.ConfigParser.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses
{
    public class IntegrationTestDiFixture : IDisposable
    {
        public const string COLLECTION_DEFINITION = "IntegrationTestDiFixture CollectionDefinition";

        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// This is required by <see cref="IConfigParserBase"/> concrete class constructor.
        /// </summary>
        public static IConfiguration Configuration { get; private set; }

        public IntegrationTestDiFixture()
        {
            Configuration = GetCustomConfiguration();

            var services = new ServiceCollection();

            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration); // Register IConfiguration instance
            services.Scan(scan => scan
                .FromAssemblyOf<IntegrationTestBase>()

                    // Register ConfigParsers
                    .AddClasses(classes => classes.AssignableTo<IConfigParserBase>())
                    .AsSelfWithInterfaces()
                    .WithScopedLifetime()
            );
        }

        private static IConfiguration GetCustomConfiguration()
        {
            const string CUSTOM_CONFIG_FILE = "custom-settings.json";   // <- This can be passed as a parameter.

            var configuration = ConfigBuilder.GetConfiguration()
                .AddJsonFile("appsettings.json")
                .AddJsonFile(CUSTOM_CONFIG_FILE)                        // <- Will search for files in the current directory. See Getting Started on how to CopyToOutputDirectory.
                .Build();

            return configuration;
        }

        public void Dispose()
        {
        }
    }

    [CollectionDefinition(IntegrationTestDiFixture.COLLECTION_DEFINITION)]
    public class ClassFactoryFixtureCollectionDefinition : ICollectionFixture<IntegrationTestDiFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
