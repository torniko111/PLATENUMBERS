﻿using AutoMapper;
using MediatR;
using Platenumbers.Application.Contracts.Persistance;
using Platenumbers.Application.Exceptions;
using Platenumbers.Application.Features.PlateNumber.Queries.GetPlateNumberDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Queries.PlateNumbersPaginationOrdering
{
    public class GetPlateNumbersPaginationOrderingQueryHandler : IRequestHandler<GetPlateNumbersPaginationOrderingQuery, List<PlateNumbersPaginationOrderingDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetPlateNumbersPaginationOrderingQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<PlateNumbersPaginationOrderingDto>> Handle(GetPlateNumbersPaginationOrderingQuery request, CancellationToken cancellationToken)
        {

            // Query the database
            var PlateNumber = await _unitOfWork.Numbers.PaginationOrdering(request.numberPerPage, request.PageNumberOf, request.OrderBy);

            //verify
            if (PlateNumber == null)
            {
                throw new NotFoundException(nameof(Features.PlateNumber), request);
            }

            // convert data objects to DTO object
            var data = _mapper.Map<List<PlateNumbersPaginationOrderingDto>>(PlateNumber);

            // return list of DTO object
            return data;
        }

    }
}