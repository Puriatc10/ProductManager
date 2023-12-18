using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProductManagerTest.Application.Interfaces.Repository;
using ProductManagerTest.Domain.Models;
using ProductManagerTest.Persistance.Context;
using ProductManagerTest.Persistance.Repositories;
using ProductManagerTest.UnitTest.FakeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace ProductManagerTest.UnitTest.Systems.Repositories
{
    public class ProductRepositoryTest
    {
        private List<Product> FakeData;
        private IProductRepository _repository;

        public ProductRepositoryTest()
        {
            FakeData = ProductFake.GetFakeList(10);
            var fake = FakeData.AsQueryable();
            var mockDbContext = new Mock<DataBaseContext>();
            var mockSet = new Mock<DbSet<Product>>();

            mockSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(fake.Provider);
            mockSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(fake.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(fake.Expression);
            mockSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(() => fake.GetEnumerator());
            mockDbContext.Setup(x => x.Products).Returns(mockSet.Object);

            mockDbContext.Setup(x => x.SaveChanges()).Returns(1);

            _repository = new ProductRepository(mockDbContext.Object);
        }

        [Fact]
        public async Task Add_Should_Return_ExaclyOne_Guid()
        {
            var p = FakeData.FirstOrDefault();

            var result = await _repository.Add(p);

            Assert.NotNull(result);
            result.Should().Be(p.Id);
        }

        [Fact]
        public async Task GetById_Should_Return_ExaclyOne_Product()
        {
            var result = await _repository.GetById(ProductFake.ConstantProductId);

            Assert.NotNull(result);
            result.Should().BeOfType<Product>();
            result.Id.Should().Be(ProductFake.ConstantProductId.ToString());
        }

        [Fact]
        public async Task GetAllAvailables_Should_Return_ListOfProducts_Currectly()
        {
            var result = await _repository.GetAllAvailables();

            Assert.NotNull(result);
            result.Should().BeOfType<List<Product>>();
            result.Count.Should().Be(10);
        }
        [Fact]
        public async Task GetAllAvailables_WithFilter_UserId_Should_Return_ListOfProducts_Currectly()
        {
            var result = await _repository.GetAllAvailables(userId: ProductFake.ConstantUserId);

            Assert.NotNull(result);
            result.Should().BeOfType<List<Product>>();
            result.Count().Should().Be(3);
        }
        [Fact]
        public async Task GetAll_ByUserId_Should_Return_ListOfProducts_Currectly()
        {
            var result = await _repository.GetAllByUserId(ProductFake.ConstantUserId);

            Assert.NotNull(result);
            result.Should().BeOfType<List<Product>>();
            result.Count().Should().Be(3);
        }
        [Fact]
        public async Task Edit_Should_Return_ExaclyOne_Product_Currectly()
        {
            var fp = new Product(ProductFake.ConstantProductId);
            var result = await _repository.Edit(fp);

            Assert.NotNull(result);
            result.Should().BeOfType<Product>();
            result.Id.Should().Be(ProductFake.ConstantProductId.ToString());
        }
        [Fact]
        public async Task DeleteById_Should_Return_True()
        {
            var result = await _repository.DeleteById(ProductFake.ConstantProductId);

            Assert.True(result);
        }
    }
}
