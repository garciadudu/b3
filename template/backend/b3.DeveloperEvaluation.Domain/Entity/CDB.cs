using b3.DeveloperEvaluation.Common;
using b3.DeveloperEvaluation.Domain.Validation;
namespace b3.DeveloperEvaluation.Domain.Entity;

public class CDB : BaseEntity
{
    public DateTime DtInicial { get; set; }

    public double VI { get; set; }
    public double VF { get; set; }
    public double CDI { get; set; }
    public double TB { get; set; }
    public double IR { get; set; }

    public virtual Guid TituloId{ get; set; }

    public virtual Titulo Titulo { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new CDBValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
