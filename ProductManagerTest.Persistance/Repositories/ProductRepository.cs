using ProductManagerTest.Application.Interfaces.Repository;
using ProductManagerTest.Domain.Models;
using ProductManagerTest.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Persistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataBaseContext _context;
        public ProductRepository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }
        public Task<Guid> Add()
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteById(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Edit(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllAvailables(Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
