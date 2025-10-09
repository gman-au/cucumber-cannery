using Cucumber.Cannery.Domain;
using Cucumber.Cannery.Domain.TestAssembly;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad
{
    public interface IAssemblyScanner
    {
        public ReqnRollAssembly Perform(ProgramArguments arguments);
    }
}