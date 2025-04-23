using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSaleStatus;

public class UpdateSaleStatusRequest
{
    public SaleStatus Status { get; set; }
}