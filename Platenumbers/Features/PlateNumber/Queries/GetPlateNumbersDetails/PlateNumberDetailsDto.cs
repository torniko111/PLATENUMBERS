using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Queries.GetPlateNumberDetails
{
    public class PlateNumberDetailsDto
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public int ReserveNumberId { get; set; }
    }
}
