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
                    .AppendLine("<h2>")
                    .AppendLine(bindingType.BindingClassName)
                    .AppendLine("</h2>");

                resultBuilder
                    .AppendLine("<hr/>");

                var definitionsToRender =
                    bindingType
                        .Definitions
                        .OrderBy(o => o.SortOrder);

                foreach (var definition in definitionsToRender)
                {
                    resultBuilder
                        .AppendLine("<h4>")
                        .AppendLine($"{definition.Keyword} {definition.Description}")
                        .AppendLine("</h4>");

                    if (definition.Parameters.Any())
                    {
                        resultBuilder
                            .AppendLine("<table>")
                            .AppendLine("<tr><th>Parameter</th><th>Type</th></tr>");

                        foreach (var parameter in definition.Parameters)
                        {
                            resultBuilder
                                .AppendLine("<tr>")
                                .AppendLine("<td>")
                                .AppendLine("<code>")
                                .AppendLine(parameter.Name)
                                .AppendLine("</code>")
                                .AppendLine("</td>")
                                .AppendLine("<td>")
                                .AppendLine("<code>")
                                .AppendLine(parameter.DataType)
                                .AppendLine("</code>")
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