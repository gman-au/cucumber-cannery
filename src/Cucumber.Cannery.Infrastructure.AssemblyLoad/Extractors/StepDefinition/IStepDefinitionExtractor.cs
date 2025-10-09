using Cucumber.Cannery.Domain.TestAssembly;
using Mono.Cecil;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.StepDefinition
{
    public interface IStepDefinitionExtractor
    {
        public bool IsApplicable(MethodDefinition method);

        public ReqnRollStepDefinition Perform(MethodDefinition method, TypeDefinition type, ref string environment);
    }
}