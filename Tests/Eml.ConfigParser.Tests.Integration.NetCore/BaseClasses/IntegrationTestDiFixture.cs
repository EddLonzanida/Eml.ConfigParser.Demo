using Eml.ClassFactory.Contracts;
using Eml.ConfigParser.Helpers;
using Eml.Mef;
using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
using Xunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses
{
    public class IntegrationTestDiFixture : IDisposable
    {
        public const string COLLECTION_DEFINITION = "IntegrationTestDiFixture CollectionDefinition";

        public const string APP_PREFIX = "Eml.";

        public static IClassFactory ClassFactory { get; private set; }

        public static IConfiguration Configuration { get; private set; }

        public IntegrationTestDiFixture()
        {
            var loggerFactory = new LoggerFactory();

            Configuration = ConfigBuilder.GetConfiguration()
                .AddJsonFile("appsettings.json")
                .Build();

            var instanceRegistrations = new List<Func<ContainerConfiguration, ExportDescriptorProvider>>
            {
                r => r.WithInstance(loggerFactory),
                r => r.WithInstance(Configuration)
            };

            ClassFactory = Bootstrapper.Init(APP_PREFIX, instanceRegistrations);
        }

        public void Dispose()
        {
            Mef.ClassFactory.Dispose(ClassFactory);
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
