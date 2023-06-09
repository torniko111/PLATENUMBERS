﻿using FluentValidation;
using Platenumbers.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Application.Features.PlateNumber.Commands.CreatePlateNumber
{
    public class CreatePlateNumberCommandValidator : AbstractValidator<CreatePlateNumberCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePlateNumberCommandValidator(IUnitOfWork unitOfWork)
        {
            //RuleFor(p => p.Id)
            //    .NotNull()
            //    .MustAsync(PlateNumberMustExist);

            RuleFor(p => p.Number)
                .Length(7)
                .Matches(@"^[A-Z]{2}\d{3}[A-Z]{2}$")
                .WithMessage("ფორმატი შემდეგნაირი უნდა იყოს AA356DD.");

            RuleFor(p => p)
                .MustAsync(PlateNumberUnique)
                .WithMessage("ასეთი სახელმწიფო ნომერი მანქანისთვის უკვე არსებობს");


            this._unitOfWork = unitOfWork;
        }

        private async Task<bool> PlateNumberMustExist(int id, CancellationToken token)
        {
            var plateNumber = await _unitOfWork.Numbers.GetByIdAsync(id);
            return plateNumber != null;
        }

        private Task<bool> PlateNumberUnique(CreatePlateNumberCommand command, CancellationToken token)
        {
            return _unitOfWork.Numbers.IsPlateNumberUnique(command.Number);
        }
    }
}
