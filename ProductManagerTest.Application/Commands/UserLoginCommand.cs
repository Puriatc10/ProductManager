using MediatR;
using ProductManagerTest.Application.Dto_s;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Commands
{
    public class UserLoginCommand : IRequest<UserLoginDto>
    {
        [Required(ErrorMessage = "username is required")]
        [MaxLength(256, ErrorMessage = "username length should be under 256 characters")]
        public required string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(256, ErrorMessage = "Password length should be under 256 characters")]
        public required string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
