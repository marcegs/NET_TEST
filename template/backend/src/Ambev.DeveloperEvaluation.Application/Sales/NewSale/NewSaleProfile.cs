using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.NewSale;

public class NewSaleProfile : Profile
{
    public NewSaleProfile()
    {
        CreateMap<NewSaleCommand.NewSaleEntry, SaleProduct>();
        CreateMap<Sale, NewSaleResult>();
    }
}