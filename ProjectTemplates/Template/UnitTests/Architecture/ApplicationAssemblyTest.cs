using System;
using System.Reflection;
using FluentValidation;
using MediatR;
using NetArchTest.Rules;
using $safeprojectname$.TestHelper;
using Xunit;

namespace $safeprojectname$.Architecture
{
    public class ApplicationAssemblyTest
    {
        private readonly Types types;

        public ApplicationAssemblyTest()
        {
            this.types = Types.InAssembly(Assembly.Load(AssemblyNames.Application));
        }

        [Fact]
        public void TestDependencies()
        {
            var result = this.types
                .ShouldNot()
                .HaveDependencyOn(AssemblyNames.Persistence)
                .Or().HaveDependencyOn(AssemblyNames.PresentationWeb)
                .Or().HaveDependencyOn(AssemblyNames.Resources)
                .GetResult();

            Asserts.NetArch(result, "Application is not allowed to have any dependencies to Persistence, Presentation*, Resources");
        }

        [Fact]
        public void TestBehaviours()
        {
            var result = this.types
                .That().ResideInNamespace($"{AssemblyNames.Application}.Behaviours")
                .And().AreNotNested()
                .Should()
                .ImplementInterface(typeof(IPipelineBehavior<,>))
                .And().NotBePublic()
                .And().HaveNameEndingWith("Behaviour`2")
                .GetResult();

            Asserts.NetArch(result, "Behaviours must be internal and have postfix 'Behaviour'");
        }

        [Fact]
        public void TestContracts()
        {
            var result = this.types
                .That().ResideInNamespace("{AssemblyNames.Application}.Contracts")
                .Should()
                .BeInterfaces()
                .And().HaveNameStartingWith("I")
                .Or()
                .BeClasses()
                .And().Inherit(typeof(Attribute))
                .And().HaveNameEndingWith("Attribute")
                .GetResult();

            Asserts.NetArch(result, "Contracts must be interfaces oder attributes with correct naming");
        }

        [Fact]
        public void TestRequests()
        {
            var result = this.types
                .That().ImplementInterface(typeof(IRequest))
                .Or().ImplementInterface(typeof(IRequest<>))
                .Should()
                .HaveName("Request")
                .And().BeNested()
                // TODO: KLI -> gibt es noch nicht .And().BeNestedPublic()
                .GetResult();

            Asserts.NetArch(result, "Requests musst be nested and named 'Request'");
        }

        [Fact]
        public void TestRequestHandler()
        {
            var result = this.types
                .That().ImplementInterface(typeof(IRequestHandler<>))
                .Or().ImplementInterface(typeof(IRequestHandler<,>))
                .Should()
                .HaveName("Handler")
                .And().BeNested()
                .GetResult();

            Asserts.NetArch(result, "Handler musst be nested and named 'Handler'");
        }

        [Fact]
        public void TestRequestValidator()
        {
            var result = this.types
                .That().Inherit(typeof(AbstractValidator<>))
                .Should()
                .HaveName("Validator")
                .And().BeNested()
                .GetResult();

            Asserts.NetArch(result, "Validator musst be nested and named 'Validator'");
        }
    }
}
