using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductManagerTest.Application.Commands;
using ProductManagerTest.Application.Dto_s;
using ProductManagerTest.Application.Helpers;
using ProductManagerTest.Application.Interfaces.Repository;
using ProductManagerTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Handlers
{
    public class UserLoginHandler : IRequestHandler<UserLoginCommand, UserLoginDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserLoginHandler(IUserRepository userRepository, IConfiguration configuration) 
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<UserLoginDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetByName(request.UserName);
            if(dbUser == null)
            {
                return new UserLoginDto()
                {
                    Status = false,
                    Message = "User not found"
                };
            }
            if(! await _userRepository.CheckPassword(dbUser , request.Password , dbUser.PasswordHash))
            {
                return new UserLoginDto()
                {
                    Status = false,
                    Message = "Wrong Password"
                };
            }

            await _userRepository.SignIn(dbUser, true);
            var tokenDb = await _userRepository.GetUserToken(Guid.Parse(dbUser.Id));
            var token = await _userRepository.GetTokenValue(Guid.Parse(dbUser.Id));
            if (Token_isEmptyOrInvalid(token))
            {
                token = Generate_Token(dbUser);
                var dbToken = new IdentityUserToken<string>()
                {
                    Value = token,
                    LoginProvider = "dev",
                    Name = dbUser.UserName.ToString(),
                    UserId = dbUser.Id
                };
                if (tokenDb == null)
                    await _userRepository.CreateToken(dbToken);
                else
                    await _userRepository.UpdateToken(dbToken);
            }

            tokenDb = await _userRepository.GetUserToken(Guid.Parse(dbUser.Id));
            token = tokenDb.Value;
            return new UserLoginDto() { Status = true, Message = "successfully logged In", Token =  token };
        }

        private string Generate_Token(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim("Id", user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private bool Token_isEmptyOrInvalid(string token)
        {
            if (token == null) return true;
            var jwtToken = new JwtSecurityToken(token);
            return (jwtToken == null) || (jwtToken.ValidTo < DateTime.Now);
        }
    }
}
