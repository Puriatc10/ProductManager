using Microsoft.EntityFrameworkCore;
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
        public async Task<Guid> Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Guid.Parse(product.Id);
        }

        public async Task<bool> DeleteById(Guid productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId.ToString());
            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public async Task<Product> Edit(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            //_context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        public async Task<List<Product>> GetAllAvailables(Guid? userId = null)
        {
            var products = _context.Products.Where(x => x.IsAvailable == true && (userId != null ? x.UserId == userId.ToString() : true)).ToList();
            return products;
        }

        public async Task<List<Product>> GetAllByUserId(Guid userId)
        {
            var products = _context.Products.Where(x => x.UserId == userId.ToString()).ToList();
            return products;
        }

        public async Task<List<Product>?> GetAllExcept(Guid productId)
        {
            var res = _context.Products.Where(x => x.Id != productId.ToString()).ToList();
            return res;
        }

        public async Task<Product> GetById(Guid productId)
        {
            var product = _context.Products.Include(x => x.ProductOwner).FirstOrDefault(x => x.Id == productId.ToString());
            return product;
        }

        public async Task<bool> MakeAvailable(Product product)
        {
            product.IsAvailable = true;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product.IsAvailable;
        }

        public async Task<bool> MakeUnAvailable(Product product)
        {
            product.IsAvailable = false;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product.IsAvailable;
        }
    }
}
