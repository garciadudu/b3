using AutoMapper;
using b3.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace b3.DeveloperEvaluation.Application.CDBs.CreateCDB;

public class CreateCDBHandler : IRequestHandler<CreateCDBCommand, CreateCDBResult>
{
    private readonly ICDBRepository _CDBRepository;
    private readonly IMapper _mapper;

    public CreateCDBHandler(ICDBRepository cdbRepository, IMapper mapper)
    {
        _CDBRepository = cdbRepository;
        _mapper = mapper;
    }

    public async Task<CreateCDBResult> Handle(CreateCDBCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCDBCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cdb = _mapper.Map<Domain.Entity.CDB>(command);

        var createdCDB = await _CDBRepository.CreateAsync(cdb, cancellationToken);
        var result = _mapper.Map<CreateCDBResult>(createdCDB);

        return result;
    }
}
