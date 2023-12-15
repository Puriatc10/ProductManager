using Microsoft.AspNetCore.Identity;
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
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;
        public UserRepository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        public Task<IdentityResult> CreateAsync(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string?> CreateOrUpdateToken(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void SignIn(User? user, bool IsPersistent)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
