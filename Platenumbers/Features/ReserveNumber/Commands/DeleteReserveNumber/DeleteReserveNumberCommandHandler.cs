using AutoMapper;
using MediatR;
using Platenumbers.Application.Contracts.Logging;
using Platenumbers.Application.Contracts.Persistance;
using Platenumbers.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.ReserveNumber.Commands.DeleteReserveNumber
{
    public class DeleteReserveNumberCommandHandler : IRequestHandler<DeleteReserveNumberCommand, Unit>

    {
        private readonly IMapper _mapper;
        private readonly IReserveNumberRepository _reserveNumberRepository;
        private readonly IAppLogger<DeleteReserveNumberCommandHandler> _logger;

        public DeleteReserveNumberCommandHandler(IMapper mapper,
            IReserveNumberRepository reserveNumberRepository,
            IAppLogger<DeleteReserveNumberCommandHandler> logger)
        {
            _mapper = mapper;
            _reserveNumberRepository = reserveNumberRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteReserveNumberCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var reserveNumberToDelete = await _reserveNumberRepository.GetByIdAsync(request.Id);

            //verify
            if (reserveNumberToDelete == null)
            {
                throw new NotFoundException(nameof(PlateNumber), request.Id);
            }

            //delete from db
            await _reserveNumberRepository.DeleteAsync(reserveNumberToDelete);

            //return 
            return Unit.Value;
        }
    }

}
