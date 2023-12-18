using FluentAssertions;
using ProductManagerTest.Application.Commands;
using ProductManagerTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.UnitTest.FakeData
{
    public static class ProductFake
    {
        public static Guid ConstantUserId = Guid.Parse("2df913d1-bdca-465f-adaa-774c8ccf1b9f");
        public static Guid ConstantProductId = Guid.Parse("333913d1-bdca-465f-adaa-774c8ccf1b9f");
        private static List<Product> Data => new List<Product>()
        {
            new Product()
            {
                Name = "Test1",
                ManufactureEmail = "Test1@gmail.com",
                ManufacturePhone = "09000000001",
                ProduceDate = DateTime.Now.AddDays(111),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = ConstantUserId.ToString(),
            },
            new Product(ConstantProductId)
            {
                Name = "Test2",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = ConstantUserId.ToString(),
            },
            new Product()
            {
                Name = "Test3",
                ManufactureEmail = "Test3@gmail.com",
                ManufacturePhone = "09000000003",
                ProduceDate = DateTime.Now.AddDays(333),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = ConstantUserId.ToString(),
            },
            new Product()
            {
                Name = "Test2",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = Guid.NewGuid().ToString(),
            },
            new Product()
            {
                Name = "Test2",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = Guid.NewGuid().ToString(),
            },
            new Product()
            {
                Name = "Test2",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = Guid.NewGuid().ToString(),
            },
            new Product()
            {
                Name = "Test3",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = Guid.NewGuid().ToString(),
            },
            new Product()
            {
                Name = "Test4",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = Guid.NewGuid().ToString(),
            },
            new Product()
            {
                Name = "Test5",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = Guid.NewGuid().ToString(),
            },
            new Product()
            {
                Name = "Test6",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = Guid.NewGuid().ToString(),
            },
            new Product()
            {
                Name = "Test7",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = Guid.NewGuid().ToString(),
            },
            new Product()
            {
                Name = "Test8",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = Guid.NewGuid().ToString(),
            },
            new Product()
            {
                Name = "Test9",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = Guid.NewGuid().ToString(),
            },
            new Product()
            {
                Name = "Test10",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = Guid.NewGuid().ToString(),
            },
            new Product()
            {
                Name = "Test11",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = Guid.NewGuid().ToString(),
            },
            new Product()
            {
                Name = "Test12",
                ManufactureEmail = "Test2@gmail.com",
                ManufacturePhone = "09000000002",
                ProduceDate = DateTime.Now.AddDays(222),
                ProductOwner = new User() { Id = Guid.NewGuid().ToString() },
                UserId = Guid.NewGuid().ToString(),
            }
        };

        public static List<AddProductCommand> AddProductCommands => new List<AddProductCommand>()
        {
            new AddProductCommand()
            {
                ManufactureEmail = "Test@gmail.com",
                ManufacturePhone = "09000000000",
                Name = "testProduct",
                ProduceDate = new DateTime(1 , 1 , 1 )
            },
            new AddProductCommand()
            {
                ManufactureEmail = "Test1@gmail.com",
                ManufacturePhone = "09000000001",
                Name = "test1Product",
                ProduceDate = new DateTime(1 , 1 , 2 )
            },
            new AddProductCommand()
            {
                ManufactureEmail = "Test3@gmail.com",
                ManufacturePhone = "09000000003",
                Name = "test3Product",
                ProduceDate = new DateTime(1 , 1 , 3 )
            },
        };

        public static IQueryable<Product> GetFakeQueryable(int count)
        {
            var s = count < Data.Count ? count : Data.Count;
            return Data.Take(s).AsQueryable();
        }
        public static List<Product> GetFakeList(int count)
        {
            var s = count < Data.Count ? count : Data.Count;
            return Data.Take(s).ToList();
        }
    }


}
