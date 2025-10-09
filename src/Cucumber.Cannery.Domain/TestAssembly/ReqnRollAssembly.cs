using System.Collections.Generic;

namespace Cucumber.Cannery.Domain.TestAssembly
{
    public class ReqnRollAssembly
    {
        public string AssemblyName { get; set; }

        public string BuildConfiguration { get; set; }

        public IEnumerable<ReqnRollStepDefinition> Definitions { get; set; }
    }
}