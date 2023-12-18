using Microsoft.AspNetCore.Identity;
using ProductManagerTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.UnitTest.FakeData
{
    public static class UserFake
    {
        public static Guid ConstantUserId = Guid.Parse("999913d1-bdca-465f-adaa-774c8ccf1b9f");
        public static readonly string ConstantPassword = "12345678";

        private static List<User> Data => new List<User>
        {
           new User(ConstantUserId)
           {
                FirstName = "Test1",
                LastName = "Test1",
                PhoneNumber = "09000000001",
                Email = "Test1@gmail.com",
                UserName = "Test1user",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(ConstantPassword),
            },
            new User() 
            { 
                FirstName = "Test2",
                LastName = "Test2",
                PhoneNumber = "09000000002",
                Email = "Test2@gmail.com",
                UserName = "Test2user",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(ConstantPassword),
            },
            new User() 
            {
                FirstName = "Test3",
                LastName = "Test3",
                PhoneNumber = "09000000003",
                Email = "Test3@gmail.com",
                UserName = "Test3user",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(ConstantPassword),
            },
            new User()
            {
                FirstName = "Test4",
                LastName = "Test4",
                PhoneNumber = "09000000004",
                Email = "Test4@gmail.com",
                UserName = "Test4user",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(ConstantPassword),
            },

            new User() 
            {
                FirstName = "Test5",
                LastName = "Test5",
                PhoneNumber = "09000000005",
                Email = "Test5@gmail.com",
                UserName = "Test5user",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(ConstantPassword),
            },
            new User() 
            {
                FirstName = "Test6",
                LastName = "Test6",
                PhoneNumber = "09000000006",
                Email = "Test6@gmail.com",
                UserName = "Test6user",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(ConstantPassword),
            },
            new User() 
            {
                FirstName = "Test7",
                LastName = "Test7",
                PhoneNumber = "09000000007",
                Email = "Test7@gmail.com",
                UserName = "Test7user",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(ConstantPassword),
            },
            new User() 
            {
                FirstName = "Test8",
                LastName = "Test8",
                PhoneNumber = "09000000008",
                Email = "Test8@gmail.com",
                UserName = "Test8user",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(ConstantPassword),
            },
            new User()
            {
                FirstName = "Test9",
                LastName = "Test9",
                PhoneNumber = "09000000009",
                Email = "Test9@gmail.com",
                UserName = "Test9user",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(ConstantPassword),
            },
            new User()
            {
                FirstName = "Test10",
                LastName = "Test10",
                PhoneNumber = "09000000010",
                Email = "Test10@gmail.com",
                UserName = "Test10user",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(ConstantPassword),
            },

        };

        public static FakeIdentityResult IdentityResult => new FakeIdentityResult()
        {
            Succeeded = true,
            Errors = new List<IdentityError>()
            {
                new IdentityError()
                {
                    Code = "404",
                    Description = "Test Error Description 1"
                },
                new IdentityError()
                {
                    Code = "500",
                    Description = "Test Error Description 2"
                }
            }
        };

        public static IQueryable<User> GetFakeQueryable(int count)
        {
            var s = count < Data.Count ? count : Data.Count;
            return Data.Take(s).AsQueryable();
        }
        public static List<User> GetFakeList(int count)
        {
            var s = count < Data.Count ? count : Data.Count;
            return Data.Take(s).ToList();
        }
    }
}
