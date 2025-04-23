using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.NewSale;

public class NewSaleResponse
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public SaleStatus Status { get; set; }
    public decimal DiscountPercentage { get; set; }
    public decimal Total => DiscountApplied ? Price - (Price * DiscountPercentage / 100) : Price;
    public bool DiscountApplied => DiscountPercentage > 0;
}