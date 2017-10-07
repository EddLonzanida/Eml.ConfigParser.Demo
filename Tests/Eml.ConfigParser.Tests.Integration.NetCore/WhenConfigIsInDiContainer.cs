using System;
using Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses;
using Eml.ConfigParser.Tests.Integration.NetCore.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetCore
{
    public class WhenAConfigIsInDiContainer : IClassFixture<MefFixture>
    {
        [Fact]
        public void ServiceProvider_ShouldReturnValue()
        {
            var configuration = IntegrationTestBase.GetConfiguration();
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
            var mef = Mef.ClassFactory.MefContainer;
            var result = new Uri("http://testSite.com/home");

            var sut = mef.GetExport<ServiceUrlConfig>();

            sut.Value.ShouldBe(result);
        }

        [Fact]
        public void Mef_ShouldReturnValueWhenGenerics()
        {
            var mef = Mef.ClassFactory.MefContainer;
            var result = new Uri("http://testSite.com/home");

            var sut = mef.GetExport<IConfigBase<Uri, ServiceUrlConfig>>();

            sut.Value.ShouldBe(result);
        }
    }
}
