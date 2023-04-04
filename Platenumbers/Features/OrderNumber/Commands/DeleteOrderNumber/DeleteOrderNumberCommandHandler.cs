using AutoMapper;
using MediatR;
using Platenumbers.Application.Contracts.Logging;
using Platenumbers.Application.Contracts.Persistance;
using Platenumbers.Application.Exceptions;
using Platenumbers.Application.Features.ReserveNumber.Commands.DeleteReserveNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.OrderNumber.Commands.DeleteOrderNumber
{
    public class DeleteOrderNumberCommandHandler : IRequestHandler<DeleteReserveNumberCommand, Unit>

    {
        private readonly IMapper _mapper;
        private readonly IOrderNumberRepository _orderNumberRepository;
        private readonly IAppLogger<DeleteOrderNumberCommandHandler> _logger;

        public DeleteOrderNumberCommandHandler(IMapper mapper,
            IOrderNumberRepository orderNumberRepository,
            IAppLogger<DeleteOrderNumberCommandHandler> logger)
        {
            this._mapper = mapper;
            this._orderNumberRepository = orderNumberRepository;
            this._logger = logger;
        }
        public async Task<Unit> Handle(DeleteReserveNumberCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var reserveNumberToDelete = await _orderNumberRepository.GetByIdAsync(request.Id);

            //verify
            if (reserveNumberToDelete == null)
            {
                throw new NotFoundException(nameof(PlateNumber), request.Id);
            }

            //delete from db
            await _orderNumberRepository.DeleteAsync(reserveNumberToDelete);

            //return 
            return Unit.Value;
        }
    }

}
