using b3.DeveloperEvaluation.Domain.Entity;

namespace b3.DeveloperEvaluation.Domain.Repositories;

public interface ICDBRepository
{
    Task<CDB> CreateAsync(CDB cdb, CancellationToken cancellationToken = default);

    Task<CDB?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(Guid id, CancellationToken cancelToken = default);
}
