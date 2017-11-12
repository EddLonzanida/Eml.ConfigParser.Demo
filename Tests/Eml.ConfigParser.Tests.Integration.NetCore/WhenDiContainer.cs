using System;
using Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses;
using Eml.ConfigParser.Tests.Integration.NetCore.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;
using Eml.ConfigParser.Helpers;

namespace Eml.ConfigParser.Tests.Integration.NetCore
{
    public class WhenDiContainer : IntegrationTestBase
    {
        [Fact]
        public void ServiceProvider_ShouldReturnValue()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton(configuration)
                .AddSingleton<ServiceUrlConfig>()
                .BuildServiceProvider();
            var result = new Uri("http://testSite.com/home");

            var sut = serviceProvider.GetService<ServiceUrlConfig>();

            sut.Value.ShouldBe(result);
        }


        [Fact]
        public void Mef_ShouldReturnValue()
        {
            var result = new Uri("http://testSite.com/home");

            var sut = classFactory.GetExport<ServiceUrlConfig>();

            sut.Value.ShouldBe(result);
        }

        [Fact]
        public void Mef_ShouldReturnValueWhenGenerics()
        {
            var result = new Uri("http://testSite.com/home");

            var sut = classFactory.GetExport<IConfigBase<Uri, ServiceUrlConfig>>();

            sut.Value.ShouldBe(result);
        }
    }
}
