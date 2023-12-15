using ProductManagerTest.Domain.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace ProductManagerTest.Domain.Models
{
    public class Product : BaseModel<Guid>
    {
        public Product(string name, string email, string phone, DateTime produceDate, Guid userId)
        {
            Id = Guid.NewGuid();
            Name = name;
            ManufactureEmail = email;
            ManufacturePhone = phone;
            ProduceDate = produceDate;
            UserId = userId;
            IsAvailable = true;
        }
        public Product()
        {
            Id = Guid.NewGuid();
            IsAvailable = true;
        }
        public Product(Guid id)
        {
            Id = id;
            IsAvailable = true;
        }
        public string Name { get; set; }
        public string ManufactureEmail { get; set; }
        public string ManufacturePhone { get; set; }
        public DateTime ProduceDate { get; set; }
        public bool IsAvailable { get; set; }
        public Guid UserId { get; set; }
        public User ProductOwner { get; set; }
    }
}
