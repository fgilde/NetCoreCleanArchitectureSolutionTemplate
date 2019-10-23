using System.Reflection;
using NetArchTest.Rules;
using $safeprojectname$.TestHelper;
using Xunit;

namespace $safeprojectname$.Architecture
{
    public class DomainAssemblyTest
    {
        private readonly Types types;

        public DomainAssemblyTest()
        {
            this.types = Types.InAssembly(Assembly.Load(AssemblyNames.Domain));
        }

        [Fact]
        public void TestDependencies()
        {
            var result = this.types
                .ShouldNot()
                .HaveDependencyOn(AssemblyNames.Application)
                .Or().HaveDependencyOn(AssemblyNames.Persistence)
                .Or().HaveDependencyOn(AssemblyNames.PresentationWeb)
                .Or().HaveDependencyOn(AssemblyNames.Resources)
                .GetResult();

            Asserts.NetArch(result, "Domain is not allowed to have any dependencies to another project");
        }

        //[Fact]
        //public void TestEnumerations()
        //{
        //    var result = this.types
        //        .That()
        //        .ResideInNamespace($"{AssemblyNames.Domain}.Enumerations")
        //        .Should()
        //        .Inherit(typeof(Enumeration<>))
        //        .And().BePublic()
        //        .GetResult();

        //    Asserts.NetArch(result, "Enumerations must inherit from Enumeration<T>");
        //}

        //[Fact]
        //public void TestValueObjects()
        //{
        //    var result = this.types
        //        .That()
        //        .ResideInNamespace($"{AssemblyNames.Domain}.ValueObject")
        //        .Should()
        //        .Inherit(typeof(ValueObject))
        //        .And().BePublic()
        //        .GetResult();

        //    Asserts.NetArch(result, "ValueObjects must inherit from ValueObject");
        //}
    }
}
