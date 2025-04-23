namespace Ambev.DeveloperEvaluation.Application.Sales.NewSale;

public class NewSaleResult
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPercentage { get; set; }
    public decimal Total => DiscountApplied ? Price * DiscountPercentage : Price;
    public bool DiscountApplied => DiscountPercentage > 0;

}