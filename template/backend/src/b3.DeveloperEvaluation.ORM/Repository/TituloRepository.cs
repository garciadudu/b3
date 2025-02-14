using b3.DeveloperEvaluation.Domain.Entity;
using b3.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace b3.DeveloperEvaluation.ORM.Repository;

public class TituloRepository : ITituloRepository
{
    private readonly DefaultContext _context;

    public TituloRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Titulo> CreateAsync(Titulo titulo, CancellationToken cancellationToken)
    {
        await _context.Titulos.AddAsync(titulo);
        await _context.SaveChangesAsync();

        return titulo;
    }

    public async Task<Titulo?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Titulos.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var titulo = await GetByIdAsync(id, cancellationToken);

        if (titulo == null)
            return false;

        _context.Titulos.Remove(titulo);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<List<Titulo>> ListAsync(CancellationToken cancellationToken = default)
    {
        var list = await _context
            .Titulos
            .Include("CDBs")
            .ToListAsync(cancellationToken);

        return list;
    }

}