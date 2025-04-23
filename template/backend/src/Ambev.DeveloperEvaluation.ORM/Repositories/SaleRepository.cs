using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sale> NewSaleAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    public async Task<Sale> UpdateStatusAsync(Guid id, SaleStatus status, CancellationToken cancellationToken = default)
    {
        var sale = await _context.Sales.Where(s => s.Id == id).FirstOrDefaultAsync(cancellationToken);
        if (sale == null)
            throw new NullReferenceException($"Sale with id {id} was not found");
        
        sale.Status = status;
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    public Task<IEnumerable<Sale>> GetByUserIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}