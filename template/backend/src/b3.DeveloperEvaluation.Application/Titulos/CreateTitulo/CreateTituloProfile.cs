using AutoMapper;
using b3.DeveloperEvaluation.Application.CDBs.CreateCDB;
using b3.DeveloperEvaluation.Domain.Entity;

namespace b3.DeveloperEvaluation.Application.Titulos.CreateTitulo;

public class CreateTituloProfile: Profile
{
    public CreateTituloProfile()
    {
        CreateMap<CreateTituloCommand, Titulo>()
                .ConstructUsing(origin => new Titulo()
                 {
                     DtFinal = origin.DtFinal,
                     Empresa = origin.Empresa,
                     NomeTitulo = origin.NomeTitulo,
                     Rentabilidade = origin.Rentabilidade,
                 })
                .ForMember(dest => dest.CDBs,
                            opt => opt.MapFrom(x =>
                            x.CDBs.Select(y => new CDB()
                            {
                                DtInicial = y.DtInicial,
                                VI = y.VI,
                                VF = y.VF,
                                CDI = y.CDI,
                                TB = y.TB,
                                IR = y.IR,
                            }
                                )
                            )
                );

        CreateMap<Titulo, CreateTituloResult>()
            .ConstructUsing(origin => new CreateTituloResult()
            {
                DtFinal = origin.DtFinal,
                Empresa = origin.Empresa,
                NomeTitulo = origin.NomeTitulo,
                Rentabilidade = origin.Rentabilidade,
            })
            .ForMember(dest => dest.CDBs,
                        opt => opt.MapFrom(x =>
                        x.CDBs.Select(y => new CreateCDBResult()
                                    {
                                        DtInicial = y.DtInicial,
                                        VI = y.VI,
                                        VF = y.VF,
                                        CDI = y.CDI,
                                        TB = y.TB,
                                        IR = y.IR,
                                    }
                            )
                        )
            );

    }
}