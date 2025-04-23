using Ambev.DeveloperEvaluation.Application.Sales.UpdateSaleStats;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSaleStatus;

public class UpdateSaleStatusProfile : Profile
{
    public UpdateSaleStatusProfile()
    {
        CreateMap<UpdateSaleStatusRequest, UpdateSaleStatusCommand>();
        CreateMap<UpdateSaleStatsResult, UpdateSaleStatusResponse>();
    }
}