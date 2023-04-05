using AutoMapper;
using FluentValidation;
using MediatR;
using Platenumbers.Application.Contracts.Logging;
using Platenumbers.Application.Contracts.Persistance;
using Platenumbers.Application.Exceptions;
using Platenumbers.Application.Features.PlateNumber.Commands.CreatePlateNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.ReserveNumber.Commands.CreateReserveNumber
{
    public class CreateReserveNumberCommandHandler : IRequestHandler<CreateReserveNumberCommand, int>

    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateReserveNumberCommandHandler> _logger;

        public CreateReserveNumberCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            IAppLogger<CreateReserveNumberCommandHandler> logger)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }
        public async Task<int> Handle(CreateReserveNumberCommand request, CancellationToken cancellationToken)
        {
            //Validate


            //convert to domain entity object

            // add to database
            var reservNumberID = await _unitOfWork.Reserves.CreateAsync(request.Numbers.ToList());

            //return record id
            return reservNumberID;
        }
    }
}
