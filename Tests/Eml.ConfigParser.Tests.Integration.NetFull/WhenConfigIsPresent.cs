using System;
using Eml.ConfigParser.Tests.Integration.NetFull.Configurations;
using Shouldly;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetFull
{
    public class WhenConfigIsPresent
    {
        [Fact]
        public void Value_ShouldBeInteger()
        {
            var sut = new IntellisenseCountConfigParser();

            sut.Value.ShouldBe(15);
        }

        [Fact]
        public void Value_ShouldBeUrl()
        {
            var result = new Uri("http://testSite.com/home");

            var sut = new ServiceUrlConfigParser();

            sut.Value.ShouldBe(result);
        }

        [Fact]
        public void Value_ShouldBeConnectionString()
        {
            var sut = new DefaultConnectionString();

            sut.Value.ShouldBe("Server=.;Database=TestDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        [Fact]
        public void Value_ShouldBeTimeSpan()
        {
            var sut = new ExpiryConfigParser();

            sut.Value.Minutes.ShouldBe(30);
        }

        [Fact]
        public void Value_ShouldBeDateTime()
        {
            var result = DateTime.Parse("2009-05-08 14:40:52");
            var sut = new DueDateConfigParser();

            sut.Value.ShouldBe(result);
        }
    }
}
