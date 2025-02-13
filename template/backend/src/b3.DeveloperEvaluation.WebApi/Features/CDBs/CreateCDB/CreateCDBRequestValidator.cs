using b3.DeveloperEvaluation.Domain.Entity;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Identity;

namespace b3.DeveloperEvaluation.WebApi.Features.CDBs.CreateCDB
{
    public class CreateCDBRequestValidator: AbstractValidator<CreateCDBRequest>
    {
        public CreateCDBRequestValidator()
        {
            RuleFor(cdb => cdb.VF)
                .NotEmpty()
                .LessThan(0)
                .WithMessage("Informe o VF positivo");

            RuleFor(cdb => cdb.VI)
                .NotEmpty()
                .LessThan(0)
                .WithMessage("Informe o VI positivo");

            RuleFor(cdb => cdb.CDI)
                .NotEmpty()
                .LessThan(0)
                .WithMessage("Informe o CDI positivo");

            RuleFor(cdb => cdb.TB)
                .NotEmpty()
                .LessThan(0)
                .WithMessage("Informe o TB positivo");
        }
    }
}
