using Cucumber.Cannery.Domain.Documentation;
using Cucumber.Cannery.Domain.TestAssembly;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad
{
    public interface IHelpBinder
    {
        public void Bind(
            ReqnRollAssembly assembly,
            AssemblyDocumentation documentation
        );
    }
}