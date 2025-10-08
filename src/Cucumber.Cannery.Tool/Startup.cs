using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Cucumber.Cannery.Application;
using Cucumber.Cannery.Infrastructure.AssemblyLoad;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Configuration;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Feature;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Scenario;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Step;
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
                .AddSingleton<IFeatureExtractor, FeatureExtractor>()
                .AddSingleton<IScenarioArgumentBuilder, ScenarioArgumentBuilder>()
                .AddSingleton<IScenarioExtractor, XorNUnitScenarioExtractor>()
                .AddSingleton<IScenarioExtractor, MsTestScenarioExtractor>()
                .AddSingleton<IBuildConfiguration, BuildConfiguration>()
                .AddSingleton<IStepExtractor, StepExtractor>()
                .AddSingleton<IFileWriter, FileWriter>()
                .AddSingleton<IFileFinder, FileFinder>()
                .AddSingleton<IMarkdownRenderer, MarkdownRenderer>()
                .AddSingleton<IColourSorter, ColourSorter>()
                .AddSingleton<IProgramArgumentsParser, ProgramArgumentsParser>();

            services
                .AddLogging(o => o.AddConsole());
            
            return services;
        } 
    }
}