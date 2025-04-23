using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSaleStats;

public class UpdateSaleStatsResult
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPercentage { get; set; }
    public SaleStatus Status { get; set; }
    public decimal Total => DiscountApplied ? Price * DiscountPercentage : Price;
    public bool DiscountApplied => DiscountPercentage > 0;
}