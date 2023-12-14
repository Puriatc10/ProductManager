using Microsoft.AspNetCore.Identity;
using ProductManagerTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        // business methods for Product Domain Model (Business Models of Core layer)

        public Task<User> GetById(Guid id);
        public Task<bool> UserExists(Guid id);
        public Task<User> GetByName(string name);
        public void SignIn(User? user , bool IsPersistent);
        public Task<IdentityResult> CreateAsync(User user, string password);
        public Task<string?> CreateOrUpdateToken(User user);
    }
}
