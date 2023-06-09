﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Commands.UpdatePlateNumber
{
    public class UpdatePlateNumberCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
     
    }
}
