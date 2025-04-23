using Ambev.DeveloperEvaluation.Application.Behaviours.BehaviourInterfaces;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.NewSale;

public class NewSaleCommand : IRequest<NewSaleResult>, ISaleCreatedBehaviour
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