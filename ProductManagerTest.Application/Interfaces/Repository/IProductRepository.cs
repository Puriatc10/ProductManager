﻿using ProductManagerTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        // business methods for Product Domain Model (Business Models of Core layer)

        public Task<Product> GetById(Guid productId);
        public Task<List<Product>> GetAllAvailables(Guid? userId = null);
        public Task<List<Product>> GetAllByUserId(Guid userId);
        public Task<List<Product>?> GetAllExcept(Guid productId);
        //public Task<DateTime?> GetProduceDateExcept(Guid productId, DateTime produceDate);
        public Task<Guid> Add(Product product);
        public Task<Product> Edit(Product product);
        public Task<bool> DeleteById(Guid productId);
        public Task<bool> MakeAvailable(Product product);
        public Task<bool> MakeUnAvailable(Product product);
    }
}
