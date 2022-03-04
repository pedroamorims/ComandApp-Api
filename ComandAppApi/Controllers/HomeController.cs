using Microsoft.AspNetCore.Mvc;

namespace ComandAppApi.Controllers
{
    public class HomeController : ControllerBase
    {
        [HttpGet("")]

        public IActionResult Get()
        {
            return Ok();
        }
    }
}
