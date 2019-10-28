using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TemplateWizard;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace VSIX_CCA_ProjectTemplate
{
    public class WizardImplementation : IWizard
    {
        private ExcludeInfo excludes;
        // This method is called before opening any item that
        // has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {}

        public void ProjectFinishedGenerating(Project project)
        {
            excludes.DeleteCreatedExcludes();
        }

        // This method is only called for item templates,
        // not for project templates.
        public void ProjectItemFinishedGenerating(ProjectItem
            projectItem)
        {}

        // This method is called after the project is created.
        public void RunFinished()
        {}

        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {
            
            var window = new TemplateSettingsWindow(replacementsDictionary);
            window.ShowDialog();
            foreach (var param in window.Parameters)
                replacementsDictionary.AddOrUpdate(param.Key, param.Value);

            excludes = new ExcludeInfo(replacementsDictionary);
        }

        // This method is only called for item templates,
        // not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }

}
