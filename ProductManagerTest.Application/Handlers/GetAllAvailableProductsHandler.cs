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
    public class GetAllAvailableProductsHandler : IRequestHandler<GetAllAvailableProductsQuery, GetAllAvailableProductsDto>
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
        public GetAllAvailableProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetAllAvailableProductsDto> Handle(GetAllAvailableProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productRepository.GetAllAvailables();
                var response = new GetAllAvailableProductsDto
                {
                    Status = true,
                    Products = new List<ProductDto>()
                };
                response.Products = products.Select(x => _mapper.Map<ProductDto>(x)).ToList();
                return response;
            }
            catch (Exception ex)
            {
                return new GetAllAvailableProductsDto { Status = false, Message = ex.Message };
            }
        }
    }
}
