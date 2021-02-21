using CorePostgre.Service;
using CorePostgre.Service.RoleService;
using Microsoft.AspNetCore.Mvc;


namespace CorePostgre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var result = _roleService.Get();

            return Ok(result);
        }

        [HttpGet("find")]
        public IActionResult Get(int id)
        {
            var result = _roleService.Get(id);

            return Ok(result);
        }

        [HttpPost("insert")]
        public IActionResult Post(string name)
        {
            _roleService.Insert(name);

            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            _roleService.Delete(id);

            return Ok();
        }
    }
}
