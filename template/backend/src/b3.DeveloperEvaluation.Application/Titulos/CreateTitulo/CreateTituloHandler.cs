using AutoMapper;
using MediatR;
using FluentValidation;
using b3.DeveloperEvaluation.Domain.Repositories;

namespace b3.DeveloperEvaluation.Application.Titulos.CreateTitulo;

public class CreateTituloHandler: IRequestHandler<CreateTituloCommand, CreateTituloResult>
{
    private readonly ITituloRepository _tituloRepository;
    private readonly IMapper _mapper;

    public CreateTituloHandler(ITituloRepository tituloRepository, IMapper mapper)
    {
        _tituloRepository = tituloRepository;
        _mapper = mapper;
    }

    public async Task<CreateTituloResult> Handle(CreateTituloCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateTituloCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);


        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        foreach (var item in command.CDBs)
        {
            item.DtInicial = DateTime.UtcNow;

            var ts = command.DtFinal.Subtract(item.DtInicial);
            var meses = ts.TotalDays / 30;

            item.TB = 108 / 100;
            item.CDI = 0.9 / 100;

            item.VF = item.VI * (1 + (item.TB * item.CDI));

            if (meses <= 6)
            {
                item.IR = (item.VF * 22.5 / 100);
            }
            else if (meses <= 12)
            {
                item.IR = (item.VF * 20 / 100);
            }
            else if (meses <= 24)
            {
                item.IR = (item.VF * 17.5 / 100);
            } else if (meses > 24)
            {
                item.IR = (item.VF * 15 / 100);
            }

            item.IR  = Math.Round(item.IR, 2);
            item.VF  = Math.Round(item.VF, 2);
            item.TB  = Math.Round(item.TB, 2);
            item.CDI = Math.Round(item.CDI, 2);
        }

        var titulo = _mapper.Map<Domain.Entity.Titulo>(command);

        var createdCDB = await _tituloRepository.CreateAsync(titulo, cancellationToken);
        var result = _mapper.Map<CreateTituloResult>(createdCDB);

        return result;
    }
}
