using MediatR;
using ProductManagerTest.Application.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Commands
{
    public class DeleteProductCommand : IRequest<DeleteProductDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
