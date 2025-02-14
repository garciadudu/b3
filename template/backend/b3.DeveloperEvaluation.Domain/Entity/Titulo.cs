using b3.DeveloperEvaluation.Common;

namespace b3.DeveloperEvaluation.Domain.Entity;

public class Titulo : BaseEntity
{
    public DateTime DtFinal { get; set; }
    public string NomeTitulo { get; set; }
    public string Empresa { get; set; }
    public double Rentabilidade { get; set; }

    public virtual ICollection<CDB> CDBs { get; set; }
}
