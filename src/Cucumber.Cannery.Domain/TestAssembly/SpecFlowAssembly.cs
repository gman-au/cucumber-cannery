using System.Collections.Generic;

namespace Cucumber.Cannery.Domain.TestAssembly
{
    public class SpecFlowAssembly
    {
        public string AssemblyName { get; set; }
        
        public string BuildConfiguration { get; set; }

        public IEnumerable<SpecFlowFeature> Features { get; set; }
    }
}