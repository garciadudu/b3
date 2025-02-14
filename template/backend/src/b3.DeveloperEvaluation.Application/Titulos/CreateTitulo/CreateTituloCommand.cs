using b3.DeveloperEvaluation.Application.CDBs.CreateCDB;
using b3.DeveloperEvaluation.Domain.Validation;
using MediatR;

namespace b3.DeveloperEvaluation.Application.Titulos.CreateTitulo;

public class CreateTituloCommand: IRequest<CreateTituloResult>
{
    public DateTime DtFinal { get; set; }
    public string NomeTitulo { get; set; }
    public string Empresa { get; set; }
    public double Rentabilidade { get; set; }

    public List<CreateCDBCommand> CDBs { get; set; }

    public CreateTituloCommand()
    {
        CDBs = new List<CreateCDBCommand>();
    }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateTituloCommandValidator();
        var result = validator.Validate(this);

        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
