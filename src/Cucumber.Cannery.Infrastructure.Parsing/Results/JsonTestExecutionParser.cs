using System.IO;
using Newtonsoft.Json;
using Cucumber.Cannery.Domain;
using Cucumber.Cannery.Domain.Result;
using Cucumber.Cannery.Infrastructure.Io;

namespace Cucumber.Cannery.Infrastructure.Parsing.Results
{
    public class JsonTestExecutionParser : ITestExecutionParser
    {
        private readonly IFileFinder _fileFinder;

        public JsonTestExecutionParser(IFileFinder fileFinder)
        {
            _fileFinder = fileFinder;
        }

        public TestExecution Parse(ProgramArguments arguments)
        {
            var foundFilePath =
                _fileFinder
                    .GetFirstFound(
                        arguments.TestResultsFolder,
                        arguments.TestResultsFile
                    );
            
            var jsonString =
                File
                    .ReadAllText(foundFilePath);

            var result =
                JsonConvert
                    .DeserializeObject<TestExecution>(jsonString);

            return result;
        }
    }
}