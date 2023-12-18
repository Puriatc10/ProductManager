using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagerTest.Api.Attributes;
using ProductManagerTest.Application.Commands;
using ProductManagerTest.Application.Queries;

namespace ProductManagerTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseAuthorizeController
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);
            if(result.Status == false)
            {
                return ResultBadRequest(null, result.Message);
            }
            return ResultOk(result.Products , result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var query = new GetProductByIdQuery()
            {
                Id = id,
            };
            var result = await _mediator.Send(query);
            if (result.Status == false)
            {
                return ResultBadRequest(null, result.Message);
            }
            return ResultOk(result.Product, result.Message);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddProduct(AddProductCommand command)
        {
            var result = await _mediator.Send(command );
            if(result.Status == false)
            {
                return ResultBadRequest(null, result.Message);
            }
            return ResultOk(result.Id, result.Message);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditPost(Guid id,  EditProductCommand editProductCommand)
        {
            var command = new EditProductCommand()
            {
                Id = id,
                Name = editProductCommand.Name,
                ManufactureEmail = editProductCommand.ManufactureEmail,
                ManufacturePhone = editProductCommand.ManufacturePhone,
                IsAvailable = editProductCommand.IsAvailable,
                ProduceDate = editProductCommand.ProduceDate,
            };
            var result = await _mediator.Send(command);
            if(result.Status == false)
            {
                return ResultBadRequest(null, result.Message);
            }
            return ResultOk(result.Product);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand();
            command.Id = id;
            var result = await _mediator.Send(command);

            if(result.Status == false)
            {
                return ResultBadRequest(id, result.Message);
            }
            return ResultOk(id , "product deleted successfully");
        }
    }
}
