using Cucumber.Cannery.Domain.TestAssembly;
using Mono.Cecil;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Definition
{
    public interface IDefinitionExtractor
    {
        public ReqnRollAssembly Perform(AssemblyDefinition assembly);
    }
}