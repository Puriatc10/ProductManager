
using Microsoft.AspNetCore.Identity;
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
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(DataBaseContext dataBaseContext, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = dataBaseContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<bool> CheckPassword(User user, string password, string passwordHash)
        {
            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, passwordHash, password);
            return Task.FromResult( result == PasswordVerificationResult.Success ? true : false);
        }

        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public async Task CreateToken(IdentityUserToken<string> token)
        {
            await _context.UserTokens.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id.ToString());
            return user;
        }

        public async Task<User> GetByName(string name)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName.ToUpper() == name.ToUpper());
            return user;
        }

        public async Task<string?> GetTokenValue(Guid id)
        {
            var token = await _context.UserTokens.Where(x => x.UserId == id.ToString()).Select(x => x.Value).SingleOrDefaultAsync();
            return token;
        }

        public async Task<IdentityUserToken<string>?> GetUserToken(Guid id)
        {
            var token = await _context.UserTokens.SingleOrDefaultAsync(x => x.UserId == id.ToString());
            return token;
        }

        public async Task<string> HashPassword(User user, string password)
        {
            var result = _userManager.PasswordHasher.HashPassword(user, password);
            return result;
        }

        public async Task SignIn(User? user, bool IsPersistent)
        {
            await _signInManager.SignInAsync(user, IsPersistent);
        }

        public async Task UpdateToken(IdentityUserToken<string> token)
        {
            _context.UserTokens.Update(token);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UserExists(Guid id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id.ToString());
        }
    }
}
