using b3.DeveloperEvaluation.Domain.Entity;
using b3.DeveloperEvaluation.Domain.Validation;
using MediatR;

namespace b3.DeveloperEvaluation.Application.CDBs.CreateCDB;

public class CreateCDBCommand: IRequest<CreateCDBResult>
{
    public DateTime DtInicial { get; set; }

    public double VI { get; set; }
    public double VF { get; set; }
    public double CDI { get; set; }
    public double TB { get; set; }
    public double IR { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCDBCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
