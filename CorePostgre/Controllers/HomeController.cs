using CorePostgre.Service;
using Microsoft.AspNetCore.Mvc;

namespace CorePostgre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IOnrTableService _onrTableService;

        public HomeController(IOnrTableService onrTableService)
        {
            _onrTableService = onrTableService;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var result = _onrTableService.Get();

            return Ok(result);
        }

        [HttpGet("find")]
        public IActionResult Get(int id)
        {
            var result = _onrTableService.Get(id);

            return Ok(result);
        }

        [HttpPost("insert")]
        public IActionResult Post(string name, int roleId)
        {
            _onrTableService.Insert(name, roleId);

            return Ok();
        }
    }
}
