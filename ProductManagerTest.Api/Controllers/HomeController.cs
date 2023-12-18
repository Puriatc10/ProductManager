using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagerTest.Application.Queries;

namespace ProductManagerTest.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class HomeController : BaseController
    {
        private IMediator _mediator;
        public HomeController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAvailables()
        {
            var query = new GetAllAvailableProductsQuery();
            var result = await _mediator.Send(query);
            if (result.Status == false)
            {
                return ResultBadRequest(null, result.Message);
            }
            return ResultOk(result.Products, result.Message);
        }

        [HttpGet("userId/{id}")]
        public async Task<IActionResult> GetAllAvailablesByUserId(Guid id)
        {
            var query = new GetAllAvailableProductsByUserIdQuery();
            query.Id = id;
            var result = await _mediator.Send(query);
            if (result.Status == false)
            {
                return ResultBadRequest(null, result.Message);
            }
            return ResultOk(result.Products, result.Message);
        }
    }
}
