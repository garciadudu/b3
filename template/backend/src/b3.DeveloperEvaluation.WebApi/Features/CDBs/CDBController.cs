using AutoMapper;
using b3.DeveloperEvaluation.Application.CDBs.CreateCDB;
using b3.DeveloperEvaluation.Domain.Validation;
using b3.DeveloperEvaluation.WebApi.Common;
using b3.DeveloperEvaluation.WebApi.Features.CDBs.CreateCDB;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace b3.DeveloperEvaluation.WebApi.Features.CDBs;

[Route("api/[controller]")]
[ApiController]
public class CDBController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CDBController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCDBResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCDB([FromBody] CreateCDBRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCDBRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var command = _mapper.Map<CreateCDBCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateCDBResponse>
            {
                Success = true,
                Message = "CDB created successfully",
                Data = _mapper.Map<CreateCDBResponse>(response)
            });
    }
}
