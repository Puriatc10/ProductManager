using Microsoft.AspNetCore.Mvc;
using ProductManagerTest.Api.Attributes;

namespace ProductManagerTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseAuthorizeController
    {
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return ResultOk();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            return ResultOk();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddPost([FromBody] string value)
        {
            return ResultOk();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditPost(Guid id, [FromBody] string value)
        {
            return ResultOk();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return ResultOk();
        }
    }
}
