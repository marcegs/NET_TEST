using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSaleStats;

public class UpdateSaleStatsProfile : Profile
{
    public UpdateSaleStatsProfile()
    {
        CreateMap<Sale, UpdateSaleStatsResult>();
    }
}