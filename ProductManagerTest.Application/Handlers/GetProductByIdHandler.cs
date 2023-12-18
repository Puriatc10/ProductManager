using AutoMapper;
using MediatR;
using ProductManagerTest.Application.Dto_s;
using ProductManagerTest.Application.Interfaces.Repository;
using ProductManagerTest.Application.Queries;
using ProductManagerTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetProductByIdDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dbProduct = await _productRepository.GetById(request.Id);
                if(dbProduct == null)
                {
                    return new GetProductByIdDto()
                    {
                        Status = false,
                        Message = "product not found"
                    };
                }
                var responce = new GetProductByIdDto()
                {
                    Status = true,
                    Product = _mapper.Map<ProductDto>(dbProduct)
            };
                return responce;
            }
            catch (Exception ex) 
            {
                return new GetProductByIdDto() { Status = false , Message = ex.Message };
            }
        }
    }
}
