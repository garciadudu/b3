using b3.DeveloperEvaluation.Domain.Entity;
using b3.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace b3.DeveloperEvaluation.ORM.Repository;

public class CDBRepository: ICDBRepository
{
    private readonly DefaultContext _context;

    public CDBRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<CDB> CreateAsync(CDB cdb, CancellationToken cancellationToken = default)
    {
        await _context.Cdbs.AddAsync(cdb);
        await _context.SaveChangesAsync();

        return cdb;
    }

    public async Task<CDB?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Cdbs.FirstOrDefaultAsync(o => o.Id == id, cancellationToken); 
    }


    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cdb = await GetByIdAsync(id, cancellationToken);

        if (cdb == null)
            return false;

        _context.Cdbs.Remove(cdb);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
