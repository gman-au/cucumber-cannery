using Mono.Cecil;
using Cucumber.Cannery.Domain.TestAssembly;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Feature
{
    public interface IFeatureExtractor
    {
        public SpecFlowAssembly Perform(AssemblyDefinition assembly);
    }
}