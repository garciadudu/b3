using b3.DeveloperEvaluation.Application.CDBs.CreateCDB;

namespace b3.DeveloperEvaluation.Application.Titulos.CreateTitulo;

public class CreateTituloResult
{
    public DateTime DtFinal { get; set; }
    public string NomeTitulo { get; set; }
    public string Empresa { get; set; }
    public double Rentabilidade { get; set; }

    public List<CreateCDBResult> CDBs { get; set; }

    public CreateTituloResult()
    {
        CDBs = new List<CreateCDBResult>();
    }
}
