using b3.DeveloperEvaluation.WebApi.Features.CDBs.CreateCDB;

namespace b3.DeveloperEvaluation.WebApi.Features.Titulos.CreateTitulo;

public class CreateTituloResponse
{
    public DateTime DtFinal { get; set; }
    public string NomeTitulo { get; set; }
    public string Empresa { get; set; }
    public double Rentabilidade { get; set; }

    public virtual ICollection<CreateCDBResponse> CDBs { get; set; }

}
