using System.Collections.Generic;

namespace Cucumber.Cannery.Domain.TestAssembly
{
    public class ReqnRollBindingType
    {
        public string BindingClassName { get; set; }

        public IEnumerable<ReqnRollStepDefinition> Definitions { get; set; }
    }
}