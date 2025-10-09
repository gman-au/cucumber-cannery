using Cucumber.Cannery.Domain;
using Cucumber.Cannery.Domain.Documentation;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad
{
    public interface IDocumentationFileScanner
    {
        public AssemblyDocumentation Perform(ProgramArguments arguments);
    }
}