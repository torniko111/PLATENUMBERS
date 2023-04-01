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
        private readonly IPlateNumberRepository _plateNumberRepository;

        public UpdatePlateNumberCommandhandler(IMapper mapper, IPlateNumberRepository plateNumberRepository)
        {
            this._mapper = mapper;
            this._plateNumberRepository = plateNumberRepository;
        }

        public async Task<Unit> Handle(UpdatePlateNumberCommand request, CancellationToken cancellationToken)
        {
            //validate

            //convert to domain entity obj
            var PlateNumberToUpdate = _mapper.Map<Domain.PlateNumber>(request);

            //add to db
            await _plateNumberRepository.UpdateAsync(PlateNumberToUpdate);

            //return Unit value
            return Unit.Value;
        }
    }
}