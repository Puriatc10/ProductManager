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
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsDto>
    {
        private IProductRepository _productRepository;
        private ICurrentUserService _currentUserService;
        private IMapper _mapper;

        public GetAllProductsHandler(ICurrentUserService userService, IProductRepository productRepository, IMapper mapper)
        {
            _currentUserService = userService;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetAllProductsDto> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = _currentUserService.GetUserId();
                var products = await _productRepository.GetAllByUserId(Guid.Parse(userId));
                var response = new GetAllProductsDto
                {
                    Status = true,
                    Products = new List<ProductDto>()
                };
                response.Products = products.Select(x => _mapper.Map<ProductDto>(x)).ToList();
                return response;
            }
            catch (Exception ex)
            {
                return new GetAllProductsDto { Status = false, Message = ex.Message };
            }
        }
    }
}
