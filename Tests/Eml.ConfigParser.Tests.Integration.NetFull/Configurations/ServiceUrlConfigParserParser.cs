﻿using System;
using System.ComponentModel.Composition;

namespace Eml.ConfigParser.Tests.Integration.NetFull.Configurations
{
    [Export]
    public class ServiceUrlConfigParser : ConfigParserBase<Uri, ServiceUrlConfigParser>
    {
    }
}