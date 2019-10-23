using System;
using System.Linq;
using NetArchTest.Rules;
using Xunit;

namespace $safeprojectname$.TestHelper
{
    internal static class Asserts
    {
        public static void NetArch(TestResult result, string message = "Architecture rule broken.")
        {
            var failingTypeNames = string.Join(", ", (result.FailingTypes ?? Enumerable.Empty<Type>()).Select(t => t.FullName));
            Assert.True(result.IsSuccessful, $"{message}{Environment.NewLine}{failingTypeNames}");
        }
    }
}
