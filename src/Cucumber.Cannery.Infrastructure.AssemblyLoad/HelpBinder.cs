using System;
using System.Linq;
using Cucumber.Cannery.Domain.Documentation;
using Cucumber.Cannery.Domain.TestAssembly;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad
{
    public class HelpBinder : IHelpBinder
    {
        public void Bind(
            ReqnRollAssembly assembly,
            AssemblyDocumentation documentation)
        {
            if (documentation == null) return;

            foreach (var bindingTypes in assembly.BindingTypes)
            {
                foreach (var definition in bindingTypes.Definitions)
                {
                    var matchingMethods =
                        documentation
                            .Documentation
                            .Members
                            .Where(o => o.Name.Contains(definition.MethodName));

                    XmlMember matchedMember = null;

                    foreach (var matchingMethod in matchingMethods)
                    {
                        var matched = true;
                        if (matchingMethod.Params.Count != definition.Parameters.Count()) continue;

                        for (var i = 0; i < matchingMethod.Params.Count; i++)
                        {
                            matched &=
                                string
                                    .Equals(
                                        matchingMethod.Params[i].Name,
                                        definition.Parameters.ElementAt(i).Name,
                                        StringComparison.CurrentCultureIgnoreCase
                                    );
                        }

                        if (!matched) continue;

                        matchedMember = matchingMethod;
                        break;
                    }

                    if (matchedMember == null) continue;

                    definition.Help = matchedMember.Summary.Trim();
                    for (var i = 0; i < definition.Parameters.Count(); i++)
                    {
                        definition.Parameters.ElementAt(i).Help = matchedMember.Params[i].Description.Trim();
                    }
                }
            }
        }
    }
}