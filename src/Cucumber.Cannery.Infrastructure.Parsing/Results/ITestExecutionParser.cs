using Cucumber.Cannery.Domain;
using Cucumber.Cannery.Domain.Result;

namespace Cucumber.Cannery.Infrastructure.Parsing.Results
{
    public interface ITestExecutionParser
    {
        public TestExecution Parse(ProgramArguments arguments);
    }
}