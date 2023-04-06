using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Queries.GetAllPlateNumbers
{
    public record GetPlateNumbersQuery : IRequest<List<PlateNumberDto>>;
}
