namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.NewSale;

public class NewSaleRequest
{
    public Guid UserId { get; set; }
    public IEnumerable<NewSaleEntry> SalesEntries { get; set; }

    public class NewSaleEntry
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
    }
}