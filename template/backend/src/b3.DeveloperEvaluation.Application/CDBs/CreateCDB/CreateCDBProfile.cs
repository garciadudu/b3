using AutoMapper;
using b3.DeveloperEvaluation.Domain.Entity;

namespace b3.DeveloperEvaluation.Application.CDBs.CreateCDB;

public class CreateCDBProfile: Profile
{
    public CreateCDBProfile()
    {
        CreateMap<CreateCDBCommand, CDB>();
        CreateMap<CDB, CreateCDBResult>();
    }
}
