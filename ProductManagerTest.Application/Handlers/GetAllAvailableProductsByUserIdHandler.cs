using AutoMapper;
using MediatR;
using ProductManagerTest.Application.Dto_s;
using ProductManagerTest.Application.Interfaces.Repository;
using ProductManagerTest.Application.Interfaces.Service;
using ProductManagerTest.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Handlers
{
    public class GetAllAvailableProductsByUserIdHandler : IRequestHandler<GetAllAvailableProductsByUserIdQuery,
        GetAllAvailableProductsByUserIdDto>
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
        public GetAllAvailableProductsByUserIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetAllAvailableProductsByUserIdDto> Handle(GetAllAvailableProductsByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productRepository.GetAllAvailables(request.Id);
                var response = new GetAllAvailableProductsByUserIdDto
                {
                    Status = true,
                    Products = new List<ProductDto>()
                };
                response.Products = products.Select(x => _mapper.Map<ProductDto>(x)).ToList();
                return response;
            }
            catch (Exception ex)
            {
                return new GetAllAvailableProductsByUserIdDto { Status = false, Message = ex.Message };
            }
        }
    }
}
