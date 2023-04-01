﻿using AutoMapper;
using MediatR;
using Platenumbers.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Queries.GetAllPlateNumbers
{
    public class GetPlateNumbersQueryHandler : IRequestHandler<GetPlateNumbersQuery, List<PlateNumberDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPlateNumberRepository _plateNumberRepository;

        public GetPlateNumbersQueryHandler(IMapper mapper, IPlateNumberRepository plateNumberRepository)
        {
            this._mapper = mapper;
            this._plateNumberRepository = plateNumberRepository;
        }

        public async Task<List<PlateNumberDto>> Handle(GetPlateNumbersQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var PlateNumbers = await _plateNumberRepository.GetAsync();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<PlateNumberDto>>(PlateNumbers);

            // return list of DTO object
            return data;
        }
    }
}