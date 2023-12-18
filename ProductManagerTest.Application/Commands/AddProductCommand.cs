﻿using MediatR;
using ProductManagerTest.Application.Dto_s;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Commands
{
    public class AddProductCommand : IRequest<AddProductDto>
    {
        [Required( ErrorMessage = "name is required")]
        [MaxLength(256 , ErrorMessage = "name length should be under 256 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string ManufactureEmail { get; set; }
        [Required(ErrorMessage = "phone number is required")]
        [RegularExpression(@"^09[0-9]{9}$", ErrorMessage = "Invalid phone number.")]
        public string ManufacturePhone { get; set; }
        [Required(ErrorMessage = "produce date is required")]
        public DateTime ProduceDate { get; set; }
    }
}
