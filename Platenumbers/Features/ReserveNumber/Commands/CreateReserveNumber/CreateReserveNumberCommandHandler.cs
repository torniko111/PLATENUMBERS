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
        private readonly IReserveNumberRepository _reserveNumberRepository;
        private readonly IAppLogger<CreateReserveNumberCommandHandler> _logger;

        public CreateReserveNumberCommandHandler(IMapper mapper,
            IReserveNumberRepository reserveNumberRepository,
            IAppLogger<CreateReserveNumberCommandHandler> logger)
        {
            _mapper = mapper;
            _reserveNumberRepository = reserveNumberRepository;
            _logger = logger;
        }
        public async Task<int> Handle(CreateReserveNumberCommand request, CancellationToken cancellationToken)
        {
            //Validate


            //convert to domain entity object

            // add to database
            var reservNumberID = await _reserveNumberRepository.CreateAsync(request.Numbers.ToList());

            //return record id
            return reservNumberID;
        }
    }
}
