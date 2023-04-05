using AutoMapper;
using MediatR;
using Platenumbers.Application.Contracts.Logging;
using Platenumbers.Application.Contracts.Persistance;
using Platenumbers.Application.Features.PlateNumber.Commands.CreatePlateNumber;
using Platenumbers.Application.Features.ReserveNumber.Commands.CreateReserveNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Commands.CreateOrderNumber
{
    internal class CreateOrderNumberCommandHandler : IRequestHandler<CreateOrderNumberCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateOrderNumberCommandHandler> _logger;

        public CreateOrderNumberCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            IAppLogger<CreateOrderNumberCommandHandler> logger)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }
        public async Task<int> Handle(CreateOrderNumberCommand request, CancellationToken cancellationToken)
        {
            //Validate


            //convert to domain entity object

            // add to database
            var reservNumberID = await _unitOfWork.Orders.CreateAsync(request.Numbers.ToList());

            //return record id
            return reservNumberID;
        }

    }
}
