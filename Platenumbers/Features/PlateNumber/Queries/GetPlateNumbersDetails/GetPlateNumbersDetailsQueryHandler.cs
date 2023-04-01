using AutoMapper;
using MediatR;
using Platenumbers.Application.Contracts.Persistance;
using Platenumbers.Application.Exceptions;
using Platenumbers.Application.Features.PlateNumber.Queries.GetAllPlateNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Queries.GetPlateNumberDetails
{
    public class GetPlateNumbersDetailsQueryHandler : IRequestHandler<GetPlateNumbersDetailsQuery, PlateNumberDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IPlateNumberRepository _plateNumberRepository;

        public GetPlateNumbersDetailsQueryHandler(IMapper mapper, IPlateNumberRepository plateNumberRepository)
        {
            this._mapper = mapper;
            this._plateNumberRepository = plateNumberRepository;
        }

        public async Task<PlateNumberDetailsDto> Handle(GetPlateNumbersDetailsQuery request, CancellationToken cancellationToken)
        {

            // Query the database
            var PlateNumber = await _plateNumberRepository.GetByIdAsync(request.Id);

            //verify
            if (PlateNumber == null)
            {
                throw new NotFoundException(nameof(Features.PlateNumber), request.Id);
            }

            // convert data objects to DTO object
            var data = _mapper.Map<PlateNumberDetailsDto>(PlateNumber);

            // return list of DTO object
            return data;
        }
    }
}
