using System.Collections.Generic;

namespace Cucumber.Cannery.Domain.TestAssembly
{
    public class ReqnRollAssembly
    {
        public string AssemblyName { get; set; }
        
        public string AssemblyFullName { get; set; }
        
        public string AssemblyVersion { get; set; }

        public string BuildConfiguration { get; set; }

        public IEnumerable<ReqnRollBindingType> BindingTypes { get; set; }
    }
}