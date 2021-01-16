using Microsoft.Extensions.DependencyInjection;
using System;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Extensions
{
    public static class TestExtensions
    {
        public static T GetScopedService<T>(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var sut = scope.ServiceProvider.GetService<T>();

            return sut;
        }
    }
}
