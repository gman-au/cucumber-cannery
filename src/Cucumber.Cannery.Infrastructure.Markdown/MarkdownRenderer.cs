using System.Linq;
using System.Text;
using Cucumber.Cannery.Domain.TestAssembly;

namespace Cucumber.Cannery.Infrastructure.Markdown
{
    public class MarkdownRenderer : IMarkdownRenderer
    {
        public StringBuilder Perform(ReqnRollAssembly assembly)
        {
            var resultBuilder = new StringBuilder();

            var bindingTypesToRender =
                assembly
                    .BindingTypes
                    .Where(o => o.Definitions.Any())
                    .OrderBy(o => o.BindingClassName);

            foreach (var bindingType in bindingTypesToRender)
            {
                resultBuilder
                    .AppendLine("<h1>")
                    .AppendLine(bindingType.BindingClassName)
                    .AppendLine("</h1>");

                var definitionsToRender =
                    bindingType
                        .Definitions
                        .OrderBy(o => o.SortOrder);

                foreach (var definition in definitionsToRender)
                {
                    resultBuilder
                        .AppendLine("<h3>")
                        .AppendLine($"<code>{definition.Keyword} {definition.StepName}</code>")
                        .AppendLine("</h3>");

                    if (!string.IsNullOrEmpty(definition.Help))
                    {
                        resultBuilder
                            .AppendLine(definition.Help);
                    }

                    if (definition.Parameters.Any())
                    {
                        resultBuilder
                            .AppendLine("<table>")
                            .AppendLine("<tr><th>Parameter</th><th>Type</th>")
                            .AppendLine("</tr>");

                        foreach (var parameter in definition.Parameters)
                        {
                            resultBuilder
                                .AppendLine("<tr>")
                                .AppendLine("<td>")
                                .Append("<code>")
                                .Append(parameter.Name)
                                .Append("</code>")
                                .AppendLine("</td>")
                                .AppendLine("<td>")
                                .AppendLine("<b>")
                                .AppendLine(parameter.DataType)
                                .AppendLine("</b>");

                            if (!string.IsNullOrWhiteSpace(parameter.Help))
                                resultBuilder
                                    .AppendLine($"<br/>{parameter.Help}");

                            resultBuilder
                                .AppendLine("</td>")
                                .AppendLine("</tr>");
                        }

                        resultBuilder
                            .AppendLine("</table>");
                    }
                }
            }

            return
                resultBuilder;
        }
    }
}