using Ambev.DeveloperEvaluation.Application.Behaviours.BehaviourInterfaces;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSaleStats;

public class UpdateSaleStatusCommand : IRequest<UpdateSaleStatsResult>, ISaleUpdatedBehaviour
{
    public Guid Id { get; set; }
    public SaleStatus Status { get; set; }
}