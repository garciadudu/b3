using b3.DeveloperEvaluation.Domain.Entity;

namespace b3.DeveloperEvaluation.Domain.Repositories;

public interface ITituloRepository
{
    Task<Titulo> CreateAsync(Titulo titulo, CancellationToken cancellationToken = default);

    Task<Titulo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Titulo>> ListAsync(CancellationToken cancellationToken = default);
}
