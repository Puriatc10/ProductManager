using ProductManagerTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Interfaces
{
    public interface IProductRepository
    {
        // business methods for Product Domain Model (Business Models of Core layer)

        public Task<Product> GetById(Guid productId);
        public Task<List<Product>> GetAllAvailables(Guid? userId = null);
        public Task<List<Product>> GetAllByUserId(Guid userId);
        public Task<Guid> Add();
        public Task<Product> Edit(Guid productId);
        public Task<Product> DeleteById(Guid productId);
    }
}
