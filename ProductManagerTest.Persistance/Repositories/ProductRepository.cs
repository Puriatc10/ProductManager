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
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<bool> DeleteById(Guid productId)
        {
            var product = await _context.Products.FindAsync(productId);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Product> Edit(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return new Product(product.Id);
        }

        public async Task<List<Product>> GetAllAvailables(Guid? userId = null)
        {
            var products = _context.Products.Where(x => x.IsAvailable == true && (userId != null ? x.UserId == userId : true)).ToList();
            return products;
        }

        public async Task<List<Product>> GetAllByUserId(Guid userId)
        {
            var products = _context.Products.Where(x => x.UserId == userId).ToList();
            return products;
        }

        public async Task<Product> GetById(Guid productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
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
