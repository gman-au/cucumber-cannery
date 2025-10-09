using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Cucumber.Cannery.Application;
using Cucumber.Cannery.Infrastructure.AssemblyLoad;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Definition;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.StepDefinition;
using Cucumber.Cannery.Infrastructure.Io;
using Cucumber.Cannery.Infrastructure.Markdown;
using Cucumber.Cannery.Infrastructure.Parsing.Arguments;

namespace Cucumber.Cannery.Tool
{
    public static class Startup
    {
        public static IServiceCollection AddServices()
        {
            var services = new ServiceCollection();

            services
                .AddSingleton<ICucumberCanneryApplication, CucumberCanneryApplication>()
                .AddSingleton<IAssemblyScanner, AssemblyScanner>()
                .AddSingleton<IDocumentationFileScanner, DocumentationFileScanner>()
                .AddSingleton<IHelpBinder, HelpBinder>()
                .AddSingleton<IDefinitionExtractor, DefinitionExtractor>()
                .AddSingleton<IStepDefinitionExtractor, StepDefinitionExtractor>()
                .AddSingleton<IFileWriter, FileWriter>()
                .AddSingleton<IFileFinder, FileFinder>()
                .AddSingleton<IMarkdownRenderer, MarkdownRenderer>()
                .AddSingleton<IProgramArgumentsParser, ProgramArgumentsParser>();

            services
                .AddLogging(o => o.AddConsole());
            
            return services;
        } 
    }
}