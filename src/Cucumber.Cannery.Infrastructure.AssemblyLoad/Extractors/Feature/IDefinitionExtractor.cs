using Mono.Cecil;
using Cucumber.Cannery.Domain.TestAssembly;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Feature
{
    public interface IDefinitionExtractor
    {
        public ReqnRollAssembly Perform(AssemblyDefinition assembly);
    }
}