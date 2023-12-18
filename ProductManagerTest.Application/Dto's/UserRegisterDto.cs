using ProductManagerTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Dto_s
{
    public class UserRegisterDto : HandlerResponseBase 
    {
        public Guid UserId { get; set; }
    }
}
