using AutoMapper;
using MediatR;
using Platenumbers.Application.Contracts.Logging;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetPlateNumbersQueryHandler> _logger;

        public GetPlateNumbersQueryHandler(IMapper mapper, 
            IUnitOfWork unitOfWork,
            IAppLogger<GetPlateNumbersQueryHandler> logger)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public async Task<List<PlateNumberDto>> Handle(GetPlateNumbersQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var PlateNumbers = await _unitOfWork.Numbers.GetAsync();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<PlateNumberDto>>(PlateNumbers);

            // return list of DTO object
            _logger.LogInformation("ნომრები წამოვიდა წარმატებულად");
            return data;
        }
    }
}
