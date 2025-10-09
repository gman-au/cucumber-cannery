using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Mono.Cecil;
using Cucumber.Cannery.Domain.TestAssembly;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Utils;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.StepDefinition;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Feature
{
    public class DefinitionExtractor : IDefinitionExtractor
    {
        private readonly ILogger<DefinitionExtractor> _logger;
        private readonly IStepDefinitionExtractor _stepDefinitionExtractor;

        public DefinitionExtractor(
            ILogger<DefinitionExtractor> logger,
            IStepDefinitionExtractor stepDefinitionExtractor)
        {
            _logger = logger;
            _stepDefinitionExtractor = stepDefinitionExtractor;
        }

        public ReqnRollAssembly Perform(AssemblyDefinition assembly)
        {
            var assemblyName =
                assembly
                    .Name
                    .Name;

            var inferredBuildConfiguration = "Unknown";

            _logger
                .LogInformation($"Assembly name: [{assemblyName}]");

            var result = new ReqnRollAssembly
            {
                AssemblyName = assemblyName
            };

            var stepDefinitions = new List<ReqnRollStepDefinition>();

            foreach (var module in assembly.Modules)
            {
                foreach (var type in module.Types)
                {
                    if (type.CustomAttributes
                        .Any(
                            o =>
                                o
                                    .AttributeType.FullName == Constants.ReqnRollBindingAttributeValue
                                )
                        )
                    {
                        _logger
                            .LogInformation($"Found bound ReqnRoll class [{type.Name}] in assembly [{assemblyName}]");

                        foreach (var method in type.Methods)
                        {
                            if (!_stepDefinitionExtractor.IsApplicable(method)) continue;

                            var stepDefinition =
                                _stepDefinitionExtractor
                                    .Perform(
                                        method,
                                        type,
                                        ref inferredBuildConfiguration
                                    );

                            stepDefinitions
                                .Add(stepDefinition);

                        }
                    }
                }
            }

            result.Definitions = stepDefinitions;

            result.BuildConfiguration = inferredBuildConfiguration;

            return result;
        }
    }
}