using System.Threading.Tasks;
using $ext_safeprojectname$.Application.RequestHandling.System;
using $safeprojectname$.TestHelper;
using Xunit;

namespace $safeprojectname$.Application.System
{
    public class InitializeApplicationTest : ApplicationTest
    {
        [Fact]
        public async Task TestHandle()
        {
            await this.Mediator.Send(new InitializeApplication.Request());

            // Assert initialization
        }
    }
}
