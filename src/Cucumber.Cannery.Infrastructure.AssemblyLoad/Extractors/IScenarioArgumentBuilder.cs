using System.Collections.Generic;
using Mono.Cecil.Cil;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors
{
    public interface IScenarioArgumentBuilder
    {
        Dictionary<string, string> Build(Instruction currInstr);
    }
}