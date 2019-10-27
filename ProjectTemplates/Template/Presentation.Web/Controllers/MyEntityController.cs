using System.Threading.Tasks;
using $ext_safeprojectname$.Application.RequestHandling.MyEntity;
using $ext_safeprojectname$.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers
{
    public class MyEntityController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Ok(await Mediator.Send(new GetMyEntity.Request()));
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<MyEntity>> Create(string name)
        {
            return Ok(await Mediator.Send(new CreateMyEntity.Request { Name = name }));
        }

        [HttpGet("{id?}")]
        public async Task<ActionResult> Delete(int? id = null)
        {
            return Ok(await Mediator.Send(new DeleteMyEntity.Request { Id = id }));
        }
    }
}