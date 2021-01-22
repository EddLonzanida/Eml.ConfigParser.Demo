using Eml.ConfigParser.Tests.Integration.NetCore.Extensions;
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
            const string CURRENT_ENVIRONMENT = "Development";   //<- this can be obtained from hostContext.HostingEnvironment.EnvironmentName

            Configuration = GetCustomConfiguration(CURRENT_ENVIRONMENT);

            var services = new ServiceCollection();

            services.RegisterServices(Configuration); //<- Register IConfigParserBase

            ServiceProvider = services.BuildServiceProvider();
        }

        private static IConfiguration GetCustomConfiguration(string currentEnvironment)
        {
            const string CUSTOM_CONFIG_FILE = "custom-settings.json";

            var configuration = currentEnvironment.GetConfiguration(CUSTOM_CONFIG_FILE);    // <- Will search for files in the current directory. 

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
