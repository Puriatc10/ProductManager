using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using ProductManagerTest.Application.Commands;
using ProductManagerTest.Application.Dto_s;
using ProductManagerTest.Application.Interfaces.Repository;
using ProductManagerTest.Application.Interfaces.Service;
using ProductManagerTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, AddProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        public AddProductHandler(IProductRepository productRepository, ICurrentUserService currentUserService, IMapper mapper)
        {
            _productRepository = productRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        public async Task<AddProductDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();

            var product = _mapper.Map<Product>(request);
            product.UserId = userId;
            product.CreateDate = DateTime.Now;
            product.Id = Guid.NewGuid().ToString();
            product.IsAvailable = true;

            var products = await _productRepository.GetAllExcept(Guid.Parse(product.Id));
            if (products != null && products.Select(x => x.ManufactureEmail).Contains(request.ManufactureEmail))
            {
                return new AddProductDto()
                {
                    Status = false,
                    Message = "Email You sent is already using from another product"
                };
            }
            if (products != null && products.Select(x => x.ProduceDate.Date).Contains(request.ProduceDate.Date))
            {
                return new AddProductDto()
                {
                    Status = false,
                    Message = "Produce Date You sent is already using from another product"
                };
            }

            var productId = await _productRepository.Add(product);

            var responce = new AddProductDto()
            {
                Id = productId,
                Status = true
            };
            return responce;
        }
    }
}
