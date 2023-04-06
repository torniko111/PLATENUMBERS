using AutoMapper;
using MediatR;
using Platenumbers.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Commands.UpdatePlateNumber
{
    public class UpdatePlateNumberCommandhandler : IRequestHandler<UpdatePlateNumberCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePlateNumberCommandhandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdatePlateNumberCommand request, CancellationToken cancellationToken)
        {
            //validate

            //convert to domain entity obj
            var PlateNumberToUpdate = _mapper.Map<Domain.PlateNumber>(request);

            //add to db
            await _unitOfWork.Numbers.UpdateAsync(PlateNumberToUpdate);

            //return Unit value
            return Unit.Value;
        }
    }
}