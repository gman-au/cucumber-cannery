using System;
using Microsoft.Extensions.Logging;
using Cucumber.Cannery.Infrastructure.AssemblyLoad;
using Cucumber.Cannery.Infrastructure.Io;
using Cucumber.Cannery.Infrastructure.Markdown;
using Cucumber.Cannery.Infrastructure.Parsing.Arguments;

namespace Cucumber.Cannery.Application
{
    public class CucumberCanneryApplication : ICucumberCanneryApplication
    {
        private readonly ILogger<CucumberCanneryApplication> _logger;
        private readonly IProgramArgumentsParser _programArgumentsParser;
        private readonly IAssemblyScanner _assemblyScanner;
        private readonly IMarkdownRenderer _markdownRenderer;
        private readonly IFileWriter _fileWriter;

        public CucumberCanneryApplication(
            ILogger<CucumberCanneryApplication> logger,
            IProgramArgumentsParser programArgumentsParser, 
            IAssemblyScanner assemblyScanner,
            IMarkdownRenderer markdownRenderer,
            IFileWriter fileWriter
        )
        {
            _logger = logger;
            _programArgumentsParser = programArgumentsParser;
            _assemblyScanner = assemblyScanner;
            _markdownRenderer = markdownRenderer;
            _fileWriter = fileWriter;
        }

        public void Perform(string[] args)
        {
            try
            {
                _logger
                    .LogInformation("Starting SpecFlow Markdown generation...");

                var arguments =
                    _programArgumentsParser
                        .Parse(args);
                
                var specFlowAssembly =
                    _assemblyScanner
                        .Perform(arguments);

                var markdown =
                    _markdownRenderer
                        .Perform(
                            specFlowAssembly
                        );
                
                _fileWriter
                    .Perform(
                        markdown,
                        arguments.OutputFilePath);

                _logger
                    .LogInformation("Completed SpecFlow Markdown generation");
            }
            catch (Exception ex)
            {
                _logger
                    .LogError($"Error encountered: {ex.Message}");
            }
        }
    }
}