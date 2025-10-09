using System.Collections.Generic;
using System.Linq;
using Cucumber.Cannery.Domain.TestAssembly;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.StepDefinition;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Utils;
using Microsoft.Extensions.Logging;
using Mono.Cecil;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.Definition
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

            var bindingModules = new List<ReqnRollBindingType>();

            foreach (var module in assembly.Modules)
            foreach (var type in module.Types)
                if (type.CustomAttributes
                    .Any(o =>
                        o
                            .AttributeType.FullName == Constants.ReqnRollBindingAttributeValue
                    )
                   )
                {
                    _logger
                        .LogInformation($"Found bound ReqnRoll class [{type.Name}] in assembly [{assemblyName}]");

                    var bindingModule = new ReqnRollBindingType
                    {
                        BindingClassName = type.Name
                    };

                    var stepDefinitions = new List<ReqnRollStepDefinition>();

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

                    bindingModule.Definitions = stepDefinitions;

                    bindingModules
                        .Add(bindingModule);
                }

            result.BuildConfiguration = inferredBuildConfiguration;
            result.BindingTypes = bindingModules;

            return result;
        }
    }
}