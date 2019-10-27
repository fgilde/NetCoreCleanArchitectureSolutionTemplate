using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnvDTE;
using Microsoft.Build.Construction;
using Microsoft.VisualStudio.Shell;

namespace VSIX_CCA_ProjectTemplate
{
    internal class ExcludeInfo
    {
        private readonly Dictionary<string, string> _parameters;

        private static readonly Dictionary<string, string[]> excludes = new Dictionary<string, string[]>
        {
            { 
                "$addBlazor$", 
                new [] {
                    @"Presentation.Web\Data",
                    @"Presentation.Web\Pages",
                    @"Presentation.Web\Shared",
                    @"Presentation.Web\wwwroot\css",
                    @"Presentation.Web\_Imports.razor",
                    @"Presentation.Web\App.razor"
                }
            },
            {
                "$addWPF$",
                new [] {
                    @"Presentation.Wpf",
                }
            },
            {
                "$addConsole$",
                new [] {
                    @"Presentation.Console",
                }
            },
        };

        public IList<string> ActiveExcludes { get; }

        public ExcludeInfo(Dictionary<string, string> parameters)
        {
            _parameters = parameters;
            ActiveExcludes = excludes.Keys.Where(key => parameters.ContainsKey(key) && parameters[key] == "False").SelectMany(s => excludes[s]).ToList();
        }
        
        public void DeleteCreatedExcludes()
        {
           // List<string> projectsToDelete = new List<string>();
            string projectName = _parameters["$projectname$"];
            string destinationFolder = _parameters["$destinationdirectory$"];
            //var dte = Package.GetGlobalService(typeof(DTE)) as DTE;
            
            foreach (var toDelete in ActiveExcludes.Select(s => $"{projectName}.{s}"))
            {
                var fullPath = Path.Combine(destinationFolder, toDelete);
                if (Path.HasExtension(fullPath) && File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                } else if (Directory.Exists(fullPath))
                {
                    string projectFile = Directory.GetFiles(fullPath, "*.csproj", SearchOption.TopDirectoryOnly).FirstOrDefault();
                    if (!string.IsNullOrEmpty(projectFile))
                    {
                        //TODO: Delete project from solution
                    }

                    Directory.Delete(fullPath, true);
                }
            }
            // TODO: Before this can used, remove deleted files from containing projects
        }
    }
}