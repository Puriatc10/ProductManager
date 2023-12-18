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
    public class UserRegisterCommand : IRequest<UserRegisterDto>
    {
        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(256, ErrorMessage = "FirstName length should be under 256 characters")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(256, ErrorMessage = "LastName length should be under 256 characters")]
        public required string LastName { get; set; }
        [Required(ErrorMessage = "username is required")]
        [MaxLength(256, ErrorMessage = "username length should be under 256 characters")]
        public required string UserName { get; set; }
        [Required(ErrorMessage = "email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "phone number is required")]
        [RegularExpression(@"^09[0-9]{9}$", ErrorMessage = "Invalid phone number.")]
        public required string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#\$%\^&\*]).+$", ErrorMessage = "Password must have at least one lowercase , one uppercase , one non alphanumberic character.")]
        public required string Password { get; set; }
    }
}
