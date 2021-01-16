using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses
{
    [Collection(IntegrationTestDiFixture.COLLECTION_DEFINITION)]
    public abstract class IntegrationTestBase
    {
        protected readonly IConfiguration configuration;

        protected readonly IServiceProvider ServiceProvider;

        protected IntegrationTestBase()
        {
            configuration = IntegrationTestDiFixture.Configuration;
            ServiceProvider = IntegrationTestDiFixture.ServiceProvider;
        }
    }
}
