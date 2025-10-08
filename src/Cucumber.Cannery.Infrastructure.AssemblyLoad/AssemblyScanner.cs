using Mono.Cecil;
using Cucumber.Cannery.Domain;
using Cucumber.Cannery.Domain.TestAssembly;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Feature;
using Cucumber.Cannery.Infrastructure.Io;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad
{
    public class AssemblyScanner : IAssemblyScanner
    {
        private readonly IFeatureExtractor _featureExtractor;
        private readonly IFileFinder _fileFinder;

        public AssemblyScanner(
            IFeatureExtractor featureExtractor,
            IFileFinder fileFinder
        )
        {
            _featureExtractor = featureExtractor;
            _fileFinder = fileFinder;
        }

        public SpecFlowAssembly Perform(ProgramArguments arguments)
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
                _featureExtractor
                    .Perform(assembly);

            return result;
        }
    }
}