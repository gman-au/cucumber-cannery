using System;
using System.Collections.Generic;
using System.Linq;
using Cucumber.Cannery.Domain.TestAssembly;
using Cucumber.Cannery.Infrastructure.AssemblyLoad.Utils;
using Mono.Cecil;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad.Extractors.StepDefinition
{
    public class StepDefinitionExtractor : IStepDefinitionExtractor
    {
        private static readonly string[] ApplicableAttributes = [
            Constants.ReqnRollGivenAttributeValue,
            Constants.ReqnRollWhenAttributeValue,
            Constants.ReqnRollThenAttributeValue
        ];

        public bool IsApplicable(MethodDefinition method)
        {
            var customAttributes =
                method
                    .CustomAttributes;

            var applicable =
                customAttributes
                    .Any(o =>
                        ApplicableAttributes
                            .Contains(
                                o.AttributeType.FullName)
                    );

            return applicable;
        }

        public ReqnRollStepDefinition Perform(
            MethodDefinition method,
            TypeDefinition type,
            ref string environment)
        {
            var result = new ReqnRollStepDefinition();

            var methodName =
                method
                    .Name;

            var stepAttribute =
                method
                    .CustomAttributes
                    .FirstOrDefault(o =>
                        ApplicableAttributes
                            .Contains(
                                o.AttributeType.FullName)
                    );

            if (stepAttribute == null) throw new Exception($"Could not find step attribute for [{methodName}]");

            var keyword =
                ExtractKeywordFromAttribute(stepAttribute);

            result.Keyword = keyword;

            var stepNameText =
                stepAttribute?
                    .ConstructorArguments
                    .FirstOrDefault()
                    .Value?
                    .ToString();

            if (string.IsNullOrEmpty(stepNameText)) throw new Exception($"Could not find step description for [{methodName}]");

            result.StepName = stepNameText;
            result.MethodName = methodName;

            var methodParameters =
                method
                    .Parameters;

            var resultParameters = new List<ReqnRollStepParameter>();

            foreach (var methodParameter in methodParameters)
            {
                resultParameters
                    .Add(
                        new ReqnRollStepParameter
                        {
                            Name = methodParameter.Name,
                            DataType = methodParameter.ParameterType.Name
                        }
                    );
            }

            result.Parameters = resultParameters;

            return result;
        }

        private static string ExtractKeywordFromAttribute(CustomAttribute stepAttribute)
        {
            var attributeName =
                stepAttribute
                    .AttributeType
                    .Name;

            if (string.IsNullOrEmpty(attributeName))
                throw new Exception("Unexpected empty attribute name");

            return
                attributeName
                    .Replace("Attribute", string.Empty);
        }
    }
}