using System;
using Microsoft.Extensions.Logging;
using Cucumber.Cannery.Domain;

namespace Cucumber.Cannery.Infrastructure.Parsing.Arguments
{
    public class ProgramArgumentsParser : IProgramArgumentsParser
    {
        private readonly ILogger<ProgramArgumentsParser> _logger;

        public ProgramArgumentsParser(ILogger<ProgramArgumentsParser> logger)
        {
            _logger = logger;
        }

        public ProgramArguments Parse(string[] args)
        {
            if (args.Length < 3)
                throw new Exception("Expected 3 arguments");

            var testAssemblyFolder = args[0];
            var testAssemblyFile = args[1];
            var outputPath = args[2];

            if (string.IsNullOrEmpty(testAssemblyFolder))
                throw new Exception("Assembly path argument invalid");

            if (string.IsNullOrEmpty(testAssemblyFile))
                throw new Exception("Assembly file argument invalid");

            if (string.IsNullOrEmpty(outputPath))
                throw new Exception("Output path argument invalid");

            var result = new ProgramArguments
            {
                TestAssemblyFolder = testAssemblyFolder,
                TestAssemblyFile = testAssemblyFile,
                OutputFilePath = outputPath
            };
            
            _logger
                .LogInformation(result.ToString());

            return result;
        }
    }
}