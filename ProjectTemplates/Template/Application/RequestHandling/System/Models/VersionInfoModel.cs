using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Extensions.PlatformAbstractions;

namespace $safeprojectname$.RequestHandling.System.Models
{
    public class VersionInfoModel
    {
        public string Application => this.GetType().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        public string Runtime => PlatformServices.Default.Application.RuntimeFramework.FullName;
        public string System => $"{RuntimeInformation.OSDescription} {RuntimeInformation.OSArchitecture}";
    }
}
