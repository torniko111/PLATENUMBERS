using AutoMapper;
using Platenumbers.Application.Features.PlateNumber.Queries.GetAllPlateNumbers;
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
        }
    }
}
