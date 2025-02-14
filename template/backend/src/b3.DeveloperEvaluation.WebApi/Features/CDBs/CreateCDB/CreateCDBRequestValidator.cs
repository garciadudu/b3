using b3.DeveloperEvaluation.Domain.Entity;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Identity;

namespace b3.DeveloperEvaluation.WebApi.Features.CDBs.CreateCDB;

public class CreateCDBRequestValidator: AbstractValidator<CreateCDBRequest>
{
    public CreateCDBRequestValidator()
    {
        RuleFor(cdb => cdb.VF)
            .GreaterThan(0)
            .WithMessage("Informe o VF positivo");

        RuleFor(cdb => cdb.VI)
            .GreaterThan(0)
            .WithMessage("Informe o VI positivo");
    }
}
