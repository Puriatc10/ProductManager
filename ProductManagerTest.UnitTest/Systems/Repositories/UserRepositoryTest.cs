using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

namespace ProductManagerTest.UnitTest.Systems.Repositories
{
    public class UserRepositoryTest
    {
        private List<User> FakeData { get; set; }
        private IUserRepository _userRepository;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        //private DataBaseContext _context;

        public UserRepositoryTest() 
        {
            FakeData = UserFake.GetFakeList(10);
            var fake = FakeData.AsQueryable();
            var mockDbContext = new Mock<DataBaseContext>();
            var mockSet = new Mock<DbSet<User>>();

            mockSet.As<IQueryable<User>>().Setup(x => x.Provider).Returns(fake.Provider);
            mockSet.As<IQueryable<User>>().Setup(x => x.ElementType).Returns(fake.ElementType);
            mockSet.As<IQueryable<User>>().Setup(x => x.Expression).Returns(fake.Expression);
            mockSet.As<IQueryable<User>>().Setup(x => x.GetEnumerator()).Returns(() => fake.GetEnumerator());
            mockDbContext.Setup(x => x.Users).Returns(mockSet.Object);
            mockDbContext.Setup(x => x.SaveChanges()).Returns(1);

            _userManager = new UserManager<User>(
                new UserStore<User>(mockDbContext.Object),
                null, null, null, null, null, null, null, null);


            _userRepository = new UserRepository(mockDbContext.Object , _userManager, _signInManager);
        }

        //[Fact]
        //public async Task Add_Should_Return_ExaclyOne_IdentityResult_Sacceeded()
        //{
        //    var user = FakeData.FirstOrDefault();

        //    var result = await _userRepository.CreateAsync(user , UserFake.ConstantPassword);

        //    Assert.NotNull(result);
        //    result.Should().Be(user.Id);
        //}

        [Fact]
        public async Task GetById_Should_Return_ExaclyOne_User()
        {
            var result = await _userRepository.GetById(UserFake.ConstantUserId);

            Assert.NotNull(result);
            result.Should().BeOfType<User>();
            result.Id.Should().Be(UserFake.ConstantUserId.ToString());
        }

        [Fact]
        public async Task GetByName_Should_Return_ExaclyOne_User()
        {
            var userName = FakeData.FirstOrDefault().UserName;
            var result = await _userRepository.GetByName(userName);

            Assert.NotNull(result);
            result.Should().BeOfType<User>();
            result.UserName.Should().Be(FakeData.FirstOrDefault().UserName);
        }


    }
}
