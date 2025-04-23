using Ambev.DeveloperEvaluation.Application.Sales.NewSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.NewSale;

public class NewSaleProfile : Profile
{
    public NewSaleProfile()
    {
        CreateMap<NewSaleRequest, NewSaleCommand>();
        CreateMap<NewSaleRequest.NewSaleEntry, NewSaleCommand.NewSaleEntry>();
        
        CreateMap<NewSaleResult, NewSaleResponse>();
    }
}