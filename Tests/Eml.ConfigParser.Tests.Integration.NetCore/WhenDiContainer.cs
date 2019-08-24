using System;
using Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses;
using Eml.ConfigParser.Tests.Integration.NetCore.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;
using Eml.ConfigParser.Tests.Integration.NetCore.ComplexClass;

namespace Eml.ConfigParser.Tests.Integration.NetCore
{
    public class WhenDiContainer : IntegrationTestBase
    {
        [Fact]
        public void ServiceProvider_ShouldReturnValue()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton(configuration)
                .AddSingleton<ServiceUrlConfigParser>()
                .BuildServiceProvider();
            var result = new Uri("http://testSite.com/home");

            var sut = serviceProvider.GetService<ServiceUrlConfigParser>();

            sut.Value.ShouldBe(result);
        }

        [Fact]
        public void Mef_ShouldReturnValue()
        {
            var result = new Uri("http://testSite.com/home");

            var sut = classFactory.GetExport<ServiceUrlConfigParser>();

            sut.Value.ShouldBe(result);
        }

        [Fact]
        public void Mef_ShouldReturnValueWhenGenerics()
        {
            var result = new Uri("http://testSite.com/home");

            var sut = classFactory.GetExport<IConfigParserBase<Uri, ServiceUrlConfigParser>>();

            sut.Value.ShouldBe(result);
        }

        [Fact]
        public void ComplexClass_ShouldBeDiscoverable()
        {
            var sut = classFactory.GetExport<IConfigParserBase<MyComplexClass, MyComplexClassConfigParser>>();

            sut.Value.StringSetting.ShouldBe("My Value");
        }
    }
}
