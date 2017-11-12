using System;
using System.Collections.Generic;
using Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses;
using Eml.ConfigParser.Tests.Integration.NetCore.ComplexClass;
using Eml.ConfigParser.Tests.Integration.NetCore.Configurations;
using Shouldly;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetCore
{
    public class WhenConfigIsPresent : IntegrationTestBase
    {
        [Fact]
        public void Value_ShouldBeInteger()
        {
            var sut = new IntellisenseCountConfig(configuration);
            sut.Value.ShouldBe(15);
        }

        [Fact]
        public void Value_ShouldBeUrl()
        {
            var result = new Uri("http://testSite.com/home");

            var sut = new ServiceUrlConfig(configuration);

            sut.Value.ShouldBe(result);
        }

        [Fact]
        public void Value_ShouldBeConnectionString()
        {
            var sut = new DefaultConnectionString(configuration);

            sut.Value.ShouldBe("Server=.;Database=TestDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        [Fact]
        public void Value_ShouldBeTimeSpan()
        {
            var sut = new ExpiryConfig(configuration);

            sut.Value.Minutes.ShouldBe(30);
        }

        [Fact]
        public void Value_ShouldBeDateTime()
        {
            var result = DateTime.Parse("2009-05-08 14:40:52");

            var sut = new DueDateConfig(configuration);

            sut.Value.ShouldBe(result);
        }

        [Fact]
        public void Value_ShouldBeStringList()
        {
            var result = new List<string> { "Item1", "Item2" };

            var sut = new WhiteListConfig(configuration);

            sut.Value.ShouldBe(result);
        }

        [Fact]
        public void Value_ShouldBeNumericList()
        {
            var result = new List<double> { 1.1, 2.2 };

            var sut = new NumericListConfig(configuration);

            sut.Value.ShouldBe(result);
        }

        [Fact]
        public void Value_ShouldBeUriList()
        {
            var result = new List<Uri>(new[] {
                new Uri("http://example.com"),
                new Uri("https://localhost:44355/"),
                new Uri("https://localhost:44379/") }
            );

            var sut = new UriListConfig(configuration);

            sut.Value.ShouldBe(result);
        }

        [Fact]
        public void Value_ShouldBeComplexClass()
        {
            var sut = new MyComplexClassConfig(configuration).Value;

            sut.StringSetting.ShouldBe("My Value");
            sut.IntSetting.ShouldBe(23);
            sut.AnEnum.ShouldBe(MyEnum.Lots);
            sut.ListOfValues[0].ShouldBe("Value1");
            sut.ListOfValues[1].ShouldBe("Value2");

            var firstKey = sut.Dictionary["FirstKey"];
            firstKey.Name.ShouldBe("First Class");
            firstKey.IsEnabled.ShouldBeFalse();

            var secondKey = sut.Dictionary["SecondKey"];
            secondKey.Name.ShouldBe("Second Class");
            secondKey.IsEnabled.ShouldBeTrue();

            var thirdKey = sut.Dictionary["ThirdKey"];
            thirdKey.Name.ShouldBe("Third Class");
            thirdKey.IsEnabled.ShouldBeTrue();
        }
    }

}
