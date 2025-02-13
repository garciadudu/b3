using b3.DeveloperEvaluation.Domain.Entity;
using FluentValidation;
using FluentValidation.Validators;


namespace b3.DeveloperEvaluation.Domain.Validation;

public class CDBValidator : AbstractValidator<CDB>
{
    public CDBValidator()
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