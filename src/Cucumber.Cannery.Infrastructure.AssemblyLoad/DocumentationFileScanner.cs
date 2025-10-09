using System;
using System.IO;
using System.Xml.Serialization;
using Cucumber.Cannery.Domain;
using Cucumber.Cannery.Domain.Documentation;
using Microsoft.Extensions.Logging;

namespace Cucumber.Cannery.Infrastructure.AssemblyLoad
{
    public class DocumentationFileScanner : IDocumentationFileScanner
    {
        private readonly ILogger<DocumentationFileScanner> _logger;

        public DocumentationFileScanner(ILogger<DocumentationFileScanner> logger)
        {
            _logger = logger;
        }

        public AssemblyDocumentation Perform(ProgramArguments arguments)
        {
            try
            {
                var result = new AssemblyDocumentation();

                var testAssemblyFile = arguments.TestAssemblyFile;
                var testAssemblyFolder = arguments.TestAssemblyFolder;

                // assuming same name, but .xml extension
                var testDocumentationFilePath =
                    Path
                        .ChangeExtension(
                            Path
                                .Combine(
                                    testAssemblyFolder,
                                    testAssemblyFile
                                ),
                            "xml"
                        );

                var serializer = new XmlSerializer(typeof(XmlDocumentation));

                using var reader = new StreamReader(testDocumentationFilePath);

                var documentation =
                    (XmlDocumentation)serializer
                        .Deserialize(reader);

                result.Documentation = documentation;

                return result;
            }
            catch (Exception ex)
            {
                _logger
                    .LogWarning("Cannot load associated documentation for [{path}]: {message}", arguments.TestAssemblyFile, ex.Message);

                return null;
            }
        }
    }
}