using System;
using System.Threading.Tasks;
using $ext_safeprojectname$.Application.RequestHandling.System;
using $ext_safeprojectname$.Application.RequestHandling.System.Models;
using Microsoft.AspNetCore.Mvc;
using $ext_safeprojectname$.Domain.Entities;

namespace $safeprojectname$.Controllers
{
    public class SystemController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<VersionInfoModel>> Version()
        {
            return Ok(await Mediator.Send(new GetVersion.Request()));
        }

        [HttpPost("{queue}")]
        public async Task<ActionResult> SendOnServiceBus(string queue, [FromBody] MyEntity entity)
        {
            return Ok(await Mediator.Send(new SendToServiceBus.Request
            {
                Queue = queue,
                Content = entity
            }));
        }
    }
}
