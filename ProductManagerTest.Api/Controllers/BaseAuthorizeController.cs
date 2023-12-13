using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagerTest.Api.Attributes;
using ProductManagerTest.Api.Response;

namespace ProductManagerTest.Api.Controllers
{
    [ApiController]
    [PermissionAuthorize]
    [Authorize]
    public class BaseAuthorizeController : ControllerBase
    {
        protected string AccessToken => Request.Headers.Authorization.ToString().Split(" ")[1];

        [NonAction]
        public IActionResult ResultOk(object data)
        {
            return Ok(CreateResponse.Ok(data));
        }

        [NonAction]
        public IActionResult ResultOk()
        {
            return Ok(CreateResponse.Ok());
        }

        [NonAction]
        public IActionResult ResultOk(object data, string message)
        {
            return Ok(CreateResponse.Ok(data, message));
        }

        [NonAction]
        public IActionResult ResultBadRequest(object data, string message)
        {
            return BadRequest(CreateResponse.Error(data, message));
        }
    }
}
