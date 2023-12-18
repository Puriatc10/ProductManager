using MediatR;
using ProductManagerTest.Application.Commands;
using ProductManagerTest.Application.Dto_s;
using ProductManagerTest.Application.Interfaces.Repository;
using ProductManagerTest.Application.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductDto>
    {
        private IProductRepository _productRepository;
        private ICurrentUserService _currentUserService;
        public DeleteProductHandler(IProductRepository productRepository, ICurrentUserService currentUserService)
        {
            _productRepository = productRepository;
            _currentUserService = currentUserService;
        }

        public async Task<DeleteProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var dbProduct = await _productRepository.GetById(request.Id);
            if(dbProduct == null)
            {
                return new DeleteProductDto()
                {
                    Status = false,
                    Message = "product not found"
                };
            }
            if(dbProduct.UserId != userId)
            {
                return new DeleteProductDto()
                {
                    Status= false,
                    Message = "You cannot delete a product that is not for you"
                };
            }

            var res = await _productRepository.DeleteById(request.Id);
            return new DeleteProductDto()
            {
                Status = true,
                Id = request.Id.ToString()
            };
        }
    }
}
