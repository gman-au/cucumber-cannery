namespace Cucumber.Cannery.Infrastructure.Io
{
    public interface IFileFinder
    {
        string GetFirstFound(string pathName, string fileName);
    }
}