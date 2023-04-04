using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Queries.PlateNumbersPaginationOrdering
{
    public class PlateNumbersPaginationOrderingDto
    {
        public string Number { get; set; } = string.Empty;
        public int NumbersPerPage { get; set; }
        public int PageOfNumber { get; set; }
    }
}
