using System;
using System.Threading.Tasks;
using $ext_safeprojectname$.Application.RequestHandling.System;
using $ext_safeprojectname$.Application.RequestHandling.System.Models;
using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers
{
    public class SystemController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<VersionInfoModel>> Version()
        {
            return Ok(await Mediator.Send(new GetVersion.Request()));
        }
    }
}
