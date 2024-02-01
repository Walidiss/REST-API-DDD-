using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeKitchen.Api.Controllers
{
    [Route("[controller]")]
    public class DinnersController : ApiController
    {
        [HttpGet]
        public IActionResult ListDinners()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
