using Microsoft.AspNetCore.Mvc;
using Sandbox.Data.Context;

namespace Sandbox.API.Controllers
{
    [ApiController()]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userList = _context.GetUsers();

            return Ok(userList);
        }
    }
}
