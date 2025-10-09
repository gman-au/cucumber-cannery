using System.Collections.Generic;

namespace Cucumber.Cannery.Domain.TestAssembly
{
    public class ReqnRollStepDefinition
    {
        public string Keyword { get; set; }

        public string Description { get; set; }

        public IEnumerable<ReqnRollStepParameter> Parameters { get; set; }
    }
}