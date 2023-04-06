using MediatR;
using Platenumbers.Application.Features.PlateNumber.Queries.GetPlateNumberDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Queries.PlateNumbersPaginationOrdering
{
    public record GetPlateNumbersPaginationOrderingQuery(int numberPerPage, int PageNumberOf, string? OrderBy) : IRequest<List<PlateNumbersPaginationOrderingDto>>;
}
