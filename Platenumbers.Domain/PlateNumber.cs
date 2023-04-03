using Platenumbers.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Platenumbers.Domain
{
    public class PlateNumber : BaseEntity
    {
        public string Number { get; set; } = string.Empty;
        public int? ReserveNumberId { get; set; }
        public ReserveNumber ReserveNumber { get; set; }
    }
}