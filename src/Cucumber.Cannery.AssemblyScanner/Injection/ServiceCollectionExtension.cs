using Cucumber.Cannery.Infrastructure.AssemblyLoad;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Definition;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.StepDefinition;
using Cucumber.Cannery.Infrastructure.Io;
using Microsoft.Extensions.DependencyInjection;

namespace Cucumber.Cannery.AssemblyScanner.Injection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCucumberAssemblyScannerServices(
            this IServiceCollection services)
        {
            services
                .AddSingleton<IAssemblyScanner, Infrastructure.AssemblyLoad.AssemblyScanner>()
                .AddSingleton<IDocumentationFileScanner, DocumentationFileScanner>()
                .AddSingleton<IHelpBinder, HelpBinder>()
                .AddSingleton<IDefinitionExtractor, DefinitionExtractor>()
                .AddSingleton<IStepDefinitionExtractor, StepDefinitionExtractor>()
                .AddSingleton<IFileWriter, FileWriter>()
                .AddSingleton<IFileFinder, FileFinder>();
            
            return services;
        } 
    }
}