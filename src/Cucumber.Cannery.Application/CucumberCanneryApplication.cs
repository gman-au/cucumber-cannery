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
        private readonly IDocumentationFileScanner _documentationFileScanner;
        private readonly IHelpBinder _helpBinder;
        private readonly IMarkdownRenderer _markdownRenderer;
        private readonly IFileWriter _fileWriter;

        public CucumberCanneryApplication(
            ILogger<CucumberCanneryApplication> logger,
            IProgramArgumentsParser programArgumentsParser, 
            IAssemblyScanner assemblyScanner,
            IDocumentationFileScanner documentationFileScanner,
            IMarkdownRenderer markdownRenderer,
            IFileWriter fileWriter,
            IHelpBinder helpBinder)
        {
            _logger = logger;
            _programArgumentsParser = programArgumentsParser;
            _assemblyScanner = assemblyScanner;
            _documentationFileScanner = documentationFileScanner;
            _markdownRenderer = markdownRenderer;
            _fileWriter = fileWriter;
            _helpBinder = helpBinder;
        }

        public void Perform(string[] args)
        {
            try
            {
                _logger
                    .LogInformation("Starting ReqnRoll Markdown generation...");

                var arguments =
                    _programArgumentsParser
                        .Parse(args);

                var reqnRollAssembly =
                    _assemblyScanner
                        .Perform(arguments);

                var reqnRollDocumentation =
                    _documentationFileScanner
                        .Perform(arguments);

                _helpBinder
                    .Bind(
                        reqnRollAssembly,
                        reqnRollDocumentation
                    );

                var markdown =
                    _markdownRenderer
                        .Perform(
                            reqnRollAssembly
                        );
                
                _fileWriter
                    .Perform(
                        markdown,
                        arguments.OutputFilePath);

                _logger
                    .LogInformation("Completed ReqnRoll Markdown generation");
            }
            catch (Exception ex)
            {
                _logger
                    .LogError($"Error encountered: {ex.Message}");
            }
        }
    }
}