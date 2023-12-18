using MediatR;
using ProductManagerTest.Application.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Queries
{
    public class GetAllProductsQuery : IRequest<GetAllProductsDto>
    {

    }
}
