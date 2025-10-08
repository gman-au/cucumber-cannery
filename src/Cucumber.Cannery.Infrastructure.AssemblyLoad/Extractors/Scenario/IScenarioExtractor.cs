using Mono.Cecil;
using Cucumber.Cannery.Domain.TestAssembly;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Scenario
{
    public interface IScenarioExtractor
    {
        public bool IsApplicable(MethodDefinition method);

        public SpecFlowScenario Perform(MethodDefinition method, TypeDefinition type, ref string environment);
    }
}