using ProductManagerTest.Domain.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace ProductManagerTest.Domain.Models
{
    public class Product : BaseModel<string>
    {
        public Product(string name, string email, string phone, DateTime produceDate, Guid userId)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            ManufactureEmail = email;
            ManufacturePhone = phone;
            ProduceDate = produceDate;
            UserId = userId.ToString();
            IsAvailable = true;
        }
        public Product()
        {
            Id = Guid.NewGuid().ToString();
            IsAvailable = true;
        }
        public Product(Guid id)
        {
            Id = id.ToString();
            IsAvailable = true;
        }
        public Product(Guid id , bool isAvailable)
        {
            Id = id.ToString();
            IsAvailable = isAvailable;
        }
        public string Name { get; set; }
        public string ManufactureEmail { get; set; }
        public string ManufacturePhone { get; set; }
        public DateTime ProduceDate { get; set; }
        public bool IsAvailable { get; set; }
        public string UserId { get; set; }
        public User ProductOwner { get; set; }
    }
}
