using b3.DeveloperEvaluation.Domain.Entity;

namespace b3.DeveloperEvaluation.WebApi.Features.CDBs.CreateCDB;

public class CreateCDBResponse
{
    public DateTime DtInicial { get; set; }
    public double VI { get; set; }
    public double VF { get; set; }
    public double CDI { get; set; }
    public double TB { get; set; }
    public double IR { get; set; }
    public Guid TituloId { get; set; }
    public string MeuTitulo { get; set; }
}
