using AutoMapper;
using MediatR;
using Platenumbers.Application.Contracts.Persistance;
using Platenumbers.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Commands.DeletePlateNumber
{
    public class DeletePlateNumberCommandHandler : IRequestHandler<DeletePlateNumberCommand, Unit>
    {
        private readonly IPlateNumberRepository _plateNumberRepository;

        public DeletePlateNumberCommandHandler(IMapper mapper, IPlateNumberRepository plateNumberRepository)
        {
            this._plateNumberRepository = plateNumberRepository;
        }
        public async Task<Unit> Handle(DeletePlateNumberCommand request, CancellationToken cancellationToken)
        {
            //Retrieve
            var plateNumberToDelete = await _plateNumberRepository.GetByIdAsync(request.Id);

            //verify
            if(plateNumberToDelete == null)
            {
                throw new NotFoundException(nameof(PlateNumber), request.Id);
            }

            //delete from db
            await _plateNumberRepository.DeleteAsync(plateNumberToDelete);

            //return 
            return Unit.Value;
        }
    }
}