using System;
using System.Collections.Generic;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad.Configuration
{
    public interface IBuildConfiguration
    {
        public IEnumerable<Tuple<string, int, int, int>> Get();
    }
}