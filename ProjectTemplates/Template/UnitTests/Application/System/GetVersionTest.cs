using System;
using System.Threading.Tasks;
using $ext_safeprojectname$.Application.RequestHandling.System;
using $safeprojectname$.TestHelper;
using Xunit;

namespace $safeprojectname$.Application.System
{
    public class GetVersionTest : ApplicationTest
    {
        [Fact]
        public async Task TestHandle()
        {
            var result = await this.Mediator.Send(new GetVersion.Request());

            Assert.NotNull(result);
            Assert.Matches(@"0.[\d]+.[\d]+-[A-Za-z-0-9]*", result.Application);
            Assert.Matches(".NETCoreApp,Version=v[0-9]+.[0-9]", result.Runtime);
            Assert.False(string.IsNullOrWhiteSpace(result.System));
        }
    }
}
