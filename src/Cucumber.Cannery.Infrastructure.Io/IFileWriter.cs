using System.Text;

namespace Cucumber.Cannery.Infrastructure.Io
{
    public interface IFileWriter
    {
        public void Perform(StringBuilder result, string filePath);
    }
}