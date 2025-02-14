using AutoMapper;
using b3.DeveloperEvaluation.Application.Titulos.CreateTitulo;
using b3.DeveloperEvaluation.Domain.Repositories;
using b3.DeveloperEvaluation.Domain.Validation;
using b3.DeveloperEvaluation.ORM.Repository;
using b3.DeveloperEvaluation.WebApi.Common;
using b3.DeveloperEvaluation.WebApi.Features.Titulos.CreateTitulo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace b3.DeveloperEvaluation.WebApi.Features.Titulos;

[Route("api/[controller]")]
[ApiController]
public class TituloController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ITituloRepository _tituloRepository;

    public TituloController(IMediator mediator, IMapper mapper, ITituloRepository tituloRepository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _tituloRepository = tituloRepository;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateTituloResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTitulo([FromBody] CreateTituloRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateTituloRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var command = _mapper.Map<CreateTituloCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateTituloResponse>
        {
            Success = true,
            Message = "Titulo created successfully",
            Data = _mapper.Map<CreateTituloResponse>(response)
        });
    }

    [HttpGet("/api/Titulos")]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateTituloResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTitulos(CancellationToken cancellationToken)
    {
        var list = await _tituloRepository
            .ListAsync(cancellationToken);

        return Ok(new ApiResponseWithData<IEnumerable<CreateTituloResponse>>
        {
            Success = true,
            Message = "Titulo list successfully",
            Data = _mapper.Map<List<CreateTituloResponse>>(list)
        });
    }
}