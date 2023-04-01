using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Commands.DeletePlateNumber
{
    public class DeletePlateNumberCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}