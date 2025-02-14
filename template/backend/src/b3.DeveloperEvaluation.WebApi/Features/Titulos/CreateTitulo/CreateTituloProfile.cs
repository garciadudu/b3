using AutoMapper;
using b3.DeveloperEvaluation.Application.CDBs.CreateCDB;
using b3.DeveloperEvaluation.Application.Titulos.CreateTitulo;
using b3.DeveloperEvaluation.Domain.Entity;
using b3.DeveloperEvaluation.WebApi.Features.CDBs.CreateCDB;

namespace b3.DeveloperEvaluation.WebApi.Features.Titulos.CreateTitulo;

public class CreateTituloProfile : Profile
{
    public CreateTituloProfile()
    {
        CreateMap<CreateTituloRequest, CreateTituloCommand>()
            .ConstructUsing(origin => new CreateTituloCommand()
            {
                DtFinal = origin.DtFinal,
                Empresa = origin.Empresa,
                NomeTitulo = origin.NomeTitulo,
                Rentabilidade = origin.Rentabilidade,
            })
            .ForMember(dest => dest.CDBs,
                        opt => opt.MapFrom(x =>
                        x.CDBs.Select(y => new CreateCDBCommand()
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

        CreateMap<CreateTituloResult, CreateTituloResponse>()
            .ConstructUsing(origin => new CreateTituloResponse()
            {
                DtFinal = origin.DtFinal,
                Empresa = origin.Empresa,
                NomeTitulo = origin.NomeTitulo,
                Rentabilidade = origin.Rentabilidade,
            })
            .ForMember(dest => dest.CDBs,
                        opt => opt.MapFrom(x => 
                        x.CDBs.Select(y => new CreateCDBResponse()
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

        CreateMap<Titulo, CreateTituloResponse>()
            .ConstructUsing(origin => new CreateTituloResponse()
            {
                DtFinal = origin.DtFinal,
                Empresa = origin.Empresa,
                NomeTitulo = origin.NomeTitulo,
                Rentabilidade = origin.Rentabilidade,
            })
            .ForMember(dest => dest.CDBs,
                        opt => opt.MapFrom(x =>
                        x.CDBs.Select(y => new CreateCDBResponse()
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