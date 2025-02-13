using AutoMapper;
using b3.DeveloperEvaluation.Application.CDBs.CreateCDB;

namespace b3.DeveloperEvaluation.WebApi.Features.CDBs.CreateCDB;

public class CreateCDBProfile: Profile
{
    public CreateCDBProfile()
    {
        CreateMap<CreateCDBRequest, CreateCDBCommand>();
        CreateMap<CreateCDBResult, CreateCDBResponse>();
    }
}
