namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleProduct
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    
    public Product Product { get; set; }
    public Sale Sale { get; set; }
}