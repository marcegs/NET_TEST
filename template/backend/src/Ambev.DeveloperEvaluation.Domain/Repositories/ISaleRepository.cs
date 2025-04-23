using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository
{
    Task<Sale> NewSaleAsync(Sale sale, CancellationToken cancellationToken = default);
    Task<Sale> UpdateStatusAsync(Guid id, SaleStatus status, CancellationToken cancellationToken = default);

    Task<IEnumerable<Sale>> GetByUserIdAsync(Guid id, CancellationToken cancellationToken = default);
}