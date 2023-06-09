﻿using AutoMapper;
using Platenumbers.Application.Features.PlateNumber.Commands.CreatePlateNumber;
using Platenumbers.Application.Features.PlateNumber.Commands.UpdatePlateNumber;
using Platenumbers.Application.Features.PlateNumber.Queries.GetAllPlateNumbers;
using Platenumbers.Application.Features.PlateNumber.Queries.GetPlateNumberDetails;
using Platenumbers.Application.Features.PlateNumber.Queries.PlateNumbersPaginationOrdering;
using Platenumbers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.MappingProfiles
{
    public class PlateNumberProfile : Profile
    {
        public PlateNumberProfile()
        {
            CreateMap<PlateNumberDto, PlateNumber>().ReverseMap();
            CreateMap<PlateNumber, PlateNumberDetailsDto>();
            CreateMap<CreatePlateNumberCommand, PlateNumber>();
            CreateMap<UpdatePlateNumberCommand, PlateNumber>();


           
            CreateMap<PlateNumbersPaginationOrderingDto, PlateNumber>().ReverseMap();
            CreateMap<PlateNumber, PlateNumbersPaginationOrderingDto>();

        }
    }
}
