using Eml.ClassFactory.Contracts;
using Eml.ConfigParser.Helpers;
using Eml.Mef;
using System;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses
{
    public class IntegrationTestDiFixture : IDisposable
    {
        public const string COLLECTION_DEFINITION = "IntegrationTestDiFixture CollectionDefinition";
        public static IClassFactory ClassFactory { get; private set; }
        public static IConfiguration Configuration { get; private set; }

        public IntegrationTestDiFixture()
        {
            var configuration = ConfigBuilder.GetConfiguration();

            ExportDescriptorProvider InstanceRegistration(ContainerConfiguration r) => r.WithInstance(configuration);

            ClassFactory = Bootstrapper.Init(InstanceRegistration);
            Configuration = ConfigBuilder.GetConfiguration();
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
