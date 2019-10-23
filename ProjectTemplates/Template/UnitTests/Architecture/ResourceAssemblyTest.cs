using System.Reflection;
using $safeprojectname$.TestHelper;
using Xunit;
using NetArchTest.Rules;

namespace $safeprojectname$.Architecture
{
    public class ResourceAssemblyTest
    {
        private readonly Types types;

        public ResourceAssemblyTest()
        {
            this.types = Types.InAssembly(Assembly.Load(AssemblyNames.Resources));
        }

        [Fact]
        public void TestDependencies()
        {
            var result = this.types
                .ShouldNot()
                .HaveDependencyOn(AssemblyNames.PresentationWeb)
                .Or().HaveDependencyOn(AssemblyNames.Persistence)
                .GetResult();

            Asserts.NetArch(result, "Resource is not allowed to have any dependencies to Persistence or Presentation*");
        }

        [Fact]
        public void TestAllInternal()
        {
            var result = this.types
                .That().AreNotNested().And().DoNotHaveNameEndingWith("ServiceCollectionExtensions")
                .Should()
                .NotBePublic()
                .GetResult();

            Asserts.NetArch(result, "All Types in Resources must be internal");
        }
    }
}
