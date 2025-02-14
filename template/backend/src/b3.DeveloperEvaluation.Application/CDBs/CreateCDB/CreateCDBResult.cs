using b3.DeveloperEvaluation.Domain.Entity;

namespace b3.DeveloperEvaluation.Application.CDBs.CreateCDB;

public class CreateCDBResult
{
    public DateTime DtInicial { get; set; }

    public double VI { get; set; }
    public double VF { get; set; }
    public double CDI { get; set; }
    public double TB { get; set; }
    public double IR { get; set; }
}
