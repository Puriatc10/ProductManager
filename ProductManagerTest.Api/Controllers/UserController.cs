using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagerTest.Application.Commands;

namespace ProductManagerTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator _mediatR;

        public UserController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterCommand request)
        {
            var result = await _mediatR.Send(request);
            if (result.Status == false)
            {
                return ResultBadRequest(null, result.Message);
            }
            return ResultOk(result.UserId);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginCommand request)
        {
            var result = await _mediatR.Send(request);
            if(result.Status == false)
            {
                return ResultBadRequest(null , result.Message);
            }
            return ResultOk(result.Token);
        }
    }
}
