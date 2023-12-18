using MediatR;
using Microsoft.AspNetCore.Identity;
using ProductManagerTest.Application.Commands;
using ProductManagerTest.Application.Dto_s;
using ProductManagerTest.Application.Helpers;
using ProductManagerTest.Application.Interfaces.Repository;
using ProductManagerTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Handlers
{
    public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, UserRegisterDto>
    {
        private IUserRepository _userRepository;
        public UserRegisterHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserRegisterDto> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var dbuser = await _userRepository.GetByName(request.UserName);
            if(dbuser != null)
            {
                return new UserRegisterDto()
                {
                    Status = false,
                    Message = "User Already Exists"
                };
            }

            var user = new User(
                request.FirstName,
                request.LastName,
                request.PhoneNumber,
                request.Email,
                request.UserName,
                null);
            user.PasswordHash = await _userRepository.HashPassword(user, request.Password);

            var result = await _userRepository.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                _userRepository.SignIn(user, true);
                return new UserRegisterDto()
                {
                    Status = true,
                    UserId = Guid.Parse(user.Id)
                };
            }
            else
            {
                var errors = new List<string>();
                foreach (var error in result.Errors)
                {
                    errors.Add(error.Description);
                }
                return new UserRegisterDto()
                {
                    Status = false,
                    Message = string.Join(", ", errors)
                };
            }
        }
    }
}
