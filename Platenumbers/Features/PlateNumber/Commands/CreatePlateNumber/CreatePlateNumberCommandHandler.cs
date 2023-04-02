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

namespace Platenumbers.Application.Features.PlateNumber.Commands.CreatePlateNumber
{
    public class CreatePlateNumberCommandHandler : IRequestHandler<CreatePlateNumberCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPlateNumberRepository _plateNumberRepository;
        private readonly IAppLogger<CreatePlateNumberCommandHandler> _logger;

        public CreatePlateNumberCommandHandler( IMapper mapper, 
            IPlateNumberRepository plateNumberRepository,
            IAppLogger<CreatePlateNumberCommandHandler> logger)
        {
            this._mapper = mapper;
            this._plateNumberRepository = plateNumberRepository;
            this._logger = logger;
        }
        public async Task<int> Handle(CreatePlateNumberCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validator = new CreatePlateNumberCommandValidator(_plateNumberRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning($"ნომერი არასწორი ფორმატისაა. {0} - {1}", nameof(PlateNumber), request.Id);
                throw new BadRequestException("არასწორი ნომერი", validationResult);
            }

            //convert to domain entity object
            var plateNumberToCreate = _mapper.Map<Domain.PlateNumber>(request);

            // add to database
            await _plateNumberRepository.CreateAsync(plateNumberToCreate);

            //return record id
            return plateNumberToCreate.Id;
        }
    }
}