using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagerTest.Api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class HomeController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAvailables()
        {
            return ResultOk();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllAvailablesByUserId(Guid id)
        {
            return ResultOk();
        }
    }
}
