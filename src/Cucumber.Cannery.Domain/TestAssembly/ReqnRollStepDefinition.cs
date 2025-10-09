using System.Collections.Generic;

namespace Cucumber.Cannery.Domain.TestAssembly
{
    public class ReqnRollStepDefinition
    {
        public string Keyword { get; set; }

        public string StepName { get; set; }

        public string MethodName { get; set; }

        public string Help { get; set; }

        public IEnumerable<ReqnRollStepParameter> Parameters { get; set; }

        public int SortOrder
        {
            get
            {
                return Keyword switch
                {
                    "Given" => 1,
                    "When" => 2,
                    "Then" => 3,
                    _ => 999
                };
            }
        }

        public override string ToString() => $"{Keyword} {StepName}";
    }
}