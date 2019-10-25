using System.Collections.Generic;
using System.Linq;

namespace VSIX_CCA_ProjectTemplate
{
    internal class ExcludeInfo
    {
        private static Dictionary<string, string[]> excludes = new Dictionary<string, string[]>
        {
            { 
                "$addBlazor$", 
                new [] {
                    @"Presentation.Web\Data",
                    @"Presentation.Web\Pages",
                    @"Presentation.Web\Shared",
                    @"Presentation.Web\wwwroot\css",
                    @"Presentation.Web\wwwroot\_Imports.razor",
                    @"Presentation.Web\wwwroot\App.razor"
                }
            },
        };

        public ExcludeInfo(Dictionary<string, string> parameters)
        {
            ActiveExcludes = excludes.Keys.Where(key => parameters.ContainsKey(key) && parameters[key] == "False").SelectMany(s => excludes[s]).ToList();
        }

        public IList<string> ActiveExcludes { get;}

        public bool ShouldExclude(string fullFileName)
        {
            return false;
        }

        public bool ShouldInclude(string fullFileName)
        {
            return !ShouldExclude(fullFileName);
        }
    }
}