using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Dto_s
{
    public class GetProductByIdDto : HandlerResponseBase
    {
        public ProductDto? Product { get; set; }
    }
}
