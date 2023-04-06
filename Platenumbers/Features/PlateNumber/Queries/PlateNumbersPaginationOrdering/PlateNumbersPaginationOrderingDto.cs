using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Queries.PlateNumbersPaginationOrdering
{
    public class PlateNumbersPaginationOrderingDto
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        [JsonIgnore]
        public int NumbersPerPage { get; set; }
        [JsonIgnore]
        public int PageOfNumber { get; set; }
        [JsonIgnore]
        public string? OrderBy { get; set; } = "Id";
    }
}
