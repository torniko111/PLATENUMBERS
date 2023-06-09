﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Commands.CreatePlateNumber
{
    public class CreatePlateNumberCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
    }
}
