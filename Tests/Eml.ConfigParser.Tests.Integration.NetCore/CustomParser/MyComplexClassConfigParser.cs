using System;
using Eml.ConfigParser.Tests.Integration.NetCore.ComplexClass;
using Microsoft.Extensions.Configuration;
using Eml.ConfigParser.Parsers;

namespace Eml.ConfigParser.Tests.Integration.NetCore.CustomParser
{
    public class MyComplexClassConfigParser : IConfigParser
    {
        private IConfigurationSection _configurationSection;

        public bool CanParse(Type settingValueType, IConfigurationSection configurationSection)
        {
            _configurationSection = configurationSection;
           return typeof(MyComplexClass).IsAssignableFrom(settingValueType);
        }

        public T GetValue<T>()
        {
            var newComplexClass = new MyComplexClass();
            _configurationSection.Bind(newComplexClass);

            return (T)(object) newComplexClass;
        }

        public void Dispose()
        {
            _configurationSection = null;
        }
    }
}
