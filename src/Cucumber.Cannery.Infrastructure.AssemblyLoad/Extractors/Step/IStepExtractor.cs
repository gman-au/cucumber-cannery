using System.Collections.Generic;
using Mono.Cecil;
using Cucumber.Cannery.Domain.TestAssembly;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Step
{
    public interface IStepExtractor
    {
        IEnumerable<SpecFlowExecutionStep> Perform(
            MethodDefinition method,
            Dictionary<string, string> argumentNames);
    }
}