using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NetArchTest.Rules;
using $safeprojectname$.TestHelper;
using Xunit;

namespace $safeprojectname$.Architecture
{
    public class PersistenceAssemblyTest
    {
        private readonly Types types;

        public PersistenceAssemblyTest()
        {
            this.types = Types.InAssembly(Assembly.Load(AssemblyNames.Persistence));
        }

        [Fact]
        public void TestDependencies()
        {
            var result = this.types
                .ShouldNot()
                .HaveDependencyOn(AssemblyNames.PresentationWeb)
                .Or().HaveDependencyOn(AssemblyNames.Resources)
                .GetResult();

            Asserts.NetArch(result, "Persistence is not allowed to have any dependencies to Resources or Presentation*");
        }
    }
}
