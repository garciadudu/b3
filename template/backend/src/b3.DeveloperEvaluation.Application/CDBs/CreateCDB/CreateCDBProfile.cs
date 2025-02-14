using AutoMapper;
using b3.DeveloperEvaluation.Domain.Entity;

namespace b3.DeveloperEvaluation.Application.CDBs.CreateCDB;

public class CreateCDBProfile: Profile
{
    public CreateCDBProfile()
    {
        CreateMap<CreateCDBCommand, CDB>()
            .ConstructUsing(origin => new CDB()
            {
                VI = origin.VI,
                VF = origin.VF,
                CDI = origin.CDI,
                TB = origin.TB,
            });

        CreateMap<CDB, CreateCDBResult>()
            .ConstructUsing(origin => new CreateCDBResult()
            {
                VI = origin.VI,
                VF = origin.VF,
                CDI = origin.CDI,
                TB = origin.TB,
            });
    }
}
