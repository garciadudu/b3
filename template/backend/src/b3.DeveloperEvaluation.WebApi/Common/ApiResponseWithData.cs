using b3.DeveloperEvaluation.Domain.Validation;

namespace b3.DeveloperEvaluation.WebApi.Common;

public class ApiResponseWithData<T> : ApiResponse
{
    public T? Data { get; set; }
}
