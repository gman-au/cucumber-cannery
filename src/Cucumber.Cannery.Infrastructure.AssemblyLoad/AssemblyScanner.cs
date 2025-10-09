using Cucumber.Cannery.Domain;
using Cucumber.Cannery.Domain.TestAssembly;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Definition;
using Cucumber.Cannery.Infrastructure.Io;
using Mono.Cecil;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad
{
    public class AssemblyScanner : IAssemblyScanner
    {
        private readonly IDefinitionExtractor _definitionExtractor;
        private readonly IFileFinder _fileFinder;

        public AssemblyScanner(
            IDefinitionExtractor definitionExtractor,
            IFileFinder fileFinder
        )
        {
            _definitionExtractor = definitionExtractor;
            _fileFinder = fileFinder;
        }

        public ReqnRollAssembly Perform(ProgramArguments arguments)
        {
            var foundFilePath =
                _fileFinder
                    .GetFirstFound(
                        arguments.TestAssemblyFolder,
                        arguments.TestAssemblyFile
                    );

            var assembly =
                AssemblyDefinition
                    .ReadAssembly(foundFilePath);

            var result =
                _definitionExtractor
                    .Perform(assembly);

            return result;
        }
    }
}