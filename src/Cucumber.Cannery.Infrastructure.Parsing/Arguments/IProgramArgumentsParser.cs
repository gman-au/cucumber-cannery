using Cucumber.Cannery.Domain;

namespace Cucumber.Cannery.Infrastructure.Parsing.Arguments
{
    public interface IProgramArgumentsParser
    {
        ProgramArguments Parse(string[] args);
    }
}