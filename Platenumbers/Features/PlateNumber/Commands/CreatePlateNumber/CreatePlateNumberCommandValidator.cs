using FluentValidation;
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
        private readonly IPlateNumberRepository _plateNumberRepository;

        public CreatePlateNumberCommandValidator(IPlateNumberRepository plateNumberRepository)
        {
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(PlateNumberMustExist);
            
            RuleFor(p => p.Number)
                .NotEmpty().WithMessage("ნომერი არ შეიძლება იყოს ცარიელი")
                .NotNull()
                .Length(7).WithMessage("ნომერი უნდა იყოს 7 სიმბოლოიანი");

            RuleFor(p => p)
                .MustAsync(PlateNumberUnique)
                .WithMessage("ასეთი სახელმწიფო ნომერი მანქანისთვის უკვე არსებობს");


            this._plateNumberRepository = plateNumberRepository;
        }

        private async Task<bool> PlateNumberMustExist(int id, CancellationToken token)
        {
            var plateNumber = await _plateNumberRepository.GetByIdAsync(id);
            return plateNumber != null;
        }

        private Task<bool> PlateNumberUnique(CreatePlateNumberCommand command, CancellationToken token)
        {
            return _plateNumberRepository.IsPlateNumberUnique(command.Number);
        }
    }
}
