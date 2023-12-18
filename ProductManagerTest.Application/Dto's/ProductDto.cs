using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Dto_s
{
    public class ProductDto
    {
        public string Id { get; set; }
        //public DateTime CreateDate { get; set; }
        //public DateTime ModificatonDate { get; set; }
        public string Name { get; set; }
        public string ManufactureEmail { get; set; }
        public string ManufacturePhone { get; set; }
        public DateTime ProduceDate { get; set; }
        public bool IsAvailable { get; set; }
        public string UserId { get; set; }
    }
}
