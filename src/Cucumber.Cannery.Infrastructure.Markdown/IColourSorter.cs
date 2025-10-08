using System.Collections.Generic;
using Cucumber.Cannery.Infrastructure.Markdown.Definition;

namespace Cucumber.Cannery.Infrastructure.Markdown
{
    public interface IColourSorter
    {
       ICollection<ChartLegendItem> Sort(int passCount, int failCount, int otherCount);
    }
}