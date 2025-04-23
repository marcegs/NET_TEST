using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public Guid UserId { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPercentage { get; set; }
    public SaleStatus Status { get; set; }
    public DateTime SaleDate { get; set; }
    public DateTime LastUpdated { get; set; }
    
    public decimal Total => DiscountApplied ? Price * DiscountPercentage : Price;
    public bool DiscountApplied => DiscountPercentage > 0;
    public List<SaleProduct> SaleProducts { get; set; } = new();
}