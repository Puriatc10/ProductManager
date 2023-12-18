using AutoMapper;
using MediatR;
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
    public class EditProductHandler : IRequestHandler<EditProductCommand, EditProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public EditProductHandler(IProductRepository productRepository, ICurrentUserService currentUserService, IMapper mapper)
        {
            _productRepository = productRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        public async Task<EditProductDto> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {

            var userId = _currentUserService.GetUserId();
            var dbProduct = await _productRepository.GetById(request.Id);
            if(dbProduct == null) 
            {
                return new EditProductDto()
                {
                    Status = false,
                    Message = "product not found"
                };
            }
            if(dbProduct.ProductOwner == null)
            {
                return new EditProductDto()
                {
                    Status = false,
                    Message = "product owner not found"
                };
            }
            if(dbProduct.ProductOwner.Id != userId)
            {
                return new EditProductDto()
                {
                    Status = false,
                    Message = "You cannot edit a product that is not for you"
                };
            }
            var products = await _productRepository.GetAllExcept(request.Id);
            if (products != null && products.Select(x => x.ManufactureEmail).Contains(request.ManufactureEmail))
            {
                return new EditProductDto()
                {
                    Status = false,
                    Message = "Email You sent is already using from another product"
                };
            }
            if (products != null && products.Select(x => x.ProduceDate.Date).Contains(request.ProduceDate.Date))
            {
                return new EditProductDto()
                {
                    Status = false,
                    Message = "Produce Date You sent is already using from another product"
                };
            }

            dbProduct = _mapper.Map<Product>(request);
            dbProduct.ModificatonDate = DateTime.Now;
            dbProduct.UserId = userId;

            dbProduct = await _productRepository.Edit(dbProduct);

            return new EditProductDto()
            {
                Status = true,
                Message = "product edited successfully",
                Product = _mapper.Map<ProductDto>(dbProduct)
            };
        }
    }
}
