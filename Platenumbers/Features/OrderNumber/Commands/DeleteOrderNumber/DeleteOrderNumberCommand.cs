using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.OrderNumber.Commands.DeleteOrderNumber
{
    public class DeleteOrderNumberCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public List<string> Numbers { get; set; } = new List<string>();
    }
}
