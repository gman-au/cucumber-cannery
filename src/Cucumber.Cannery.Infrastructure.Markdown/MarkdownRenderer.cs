using System.Text;
using Cucumber.Cannery.Domain.TestAssembly;
using Cucumber.Cannery.Infrastructure.Markdown.Renderer;
using Cucumber.Cannery.Infrastructure.Markdown.Extensions;

namespace Cucumber.Cannery.Infrastructure.Markdown
{
    public class MarkdownRenderer : IMarkdownRenderer
    {
        private readonly IColourSorter _colourSorter;

        public MarkdownRenderer(IColourSorter colourSorter)
        {
            _colourSorter = colourSorter;
        }

        public StringBuilder Perform(ReqnRollAssembly assembly)
        {
            var result = new StringBuilder();
            var headerBuilder = new StringBuilder();

            /*var featureSummary =
                ResultSummariser
                    .SummariseAllFeatures(execution);

            var scenarioSummary =
                ResultSummariser
                    .SummariseAllScenarios(execution);

            var stepSummary =
                ResultSummariser
                    .SummariseAllSteps(execution);

            var tagSummary =
                ResultSummariser
                    .SummariseAllTags(
                        execution,
                        assembly
                    );

            // Render header
            headerBuilder
                .AppendLine($"# {assembly.AssemblyName}")
                .AppendLine($"##### *Build configuration: {assembly.BuildConfiguration}*");

            headerBuilder
                .AppendLine("<table>")
                .AppendLine("<tr>")
                .AppendLine("<td>")
                .AppendPieChart(
                    "Features",
                    _colourSorter
                        .Sort(
                            featureSummary.Successes,
                            featureSummary.Failures,
                            featureSummary.Others
                        )
                )
                .AppendLine("</td>")
                .AppendLine("<td>")
                .AppendPieChart(
                    "Scenarios",
                    _colourSorter
                        .Sort(
                            scenarioSummary.Successes,
                            scenarioSummary.Failures,
                            scenarioSummary.Others
                        )
                )
                .AppendLine("</td>")
                .AppendLine("<td>")
                .AppendPieChart(
                    "Steps",
                    _colourSorter
                        .Sort(
                            stepSummary.Successes,
                            stepSummary.Failures,
                            stepSummary.Others
                        )
                )
                .AppendLine("</td>")
                .AppendLine("<td>")
                .AppendTagChart(
                    "Tags",
                    tagSummary
                )
                .AppendLine("</td>")
                .AppendLine("</tr>")
                .AppendLine("</table>")
                .AppendLine();

            // TOC
            var tocBuilder = new StringBuilder();
            tocBuilder
                .AppendLine()
                .AppendLine("<table>")
                .AppendLine("<tr>");

            foreach (var header in new[] { "Feature", "Scenario", "Case", "Passed", "Failed", "Skipped", "Time" })
            {
                tocBuilder
                    .AppendLine($"<th>{header}</th>");
            }

            tocBuilder
                .AppendLine("<tr>");

            var contentBuilder = new StringBuilder();
            
            foreach (var feature in assembly.Features)
            {
                ComponentRenderer
                    .RenderFeature(
                        feature,
                        tocBuilder,
                        contentBuilder,
                        execution
                    );
            }

            tocBuilder
                .AppendLine("</table>")
                .AppendLine();

            result
                .Append(headerBuilder)
                .Append(tocBuilder)
                .Append(contentBuilder);*/

            return 
                result;
        }
    }
}