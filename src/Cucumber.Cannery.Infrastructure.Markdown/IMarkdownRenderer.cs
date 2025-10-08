using System.Text;
using Cucumber.Cannery.Domain.Result;
using Cucumber.Cannery.Domain.TestAssembly;

namespace Cucumber.Cannery.Infrastructure.Markdown
{
    public interface IMarkdownRenderer
    {
        public StringBuilder Perform(SpecFlowAssembly assembly);
    }
}