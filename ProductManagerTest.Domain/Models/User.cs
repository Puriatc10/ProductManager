using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Domain.Models
{
    public class User : IdentityUser<string>
    {
        public User(string firstName, string lastName, string phoneNumber, string email, string userName, string passwordHash)
        {
            Id = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            UserName = userName;
            PasswordHash = passwordHash;
            CreateDate = DateTime.Now;
        }
        public User()
        {
            Id = Guid.NewGuid().ToString();
            CreateDate = DateTime.Now;
        }
        public User(Guid id)
        {
            Id = id.ToString();
            CreateDate = DateTime.Now;
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
