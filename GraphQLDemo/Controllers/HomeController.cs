using Microsoft.AspNetCore.Mvc;

namespace GraphQLDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("index")]
        public IActionResult Home()
        {
            return Ok("Welcome to GraphQLDemo!");
        }
    }
}