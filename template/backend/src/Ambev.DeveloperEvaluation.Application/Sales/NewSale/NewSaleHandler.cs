using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.NewSale;

public class NewSaleHandler : IRequestHandler<NewSaleCommand, NewSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public NewSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<NewSaleResult> Handle(NewSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new NewSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = CreateSale(request);

        var newSale = await _saleRepository.NewSaleAsync(sale, cancellationToken);
        var result = _mapper.Map<NewSaleResult>(newSale);
        return result;
    }

    private Sale CreateSale(NewSaleCommand request)
    {
        var saleProducts = request.SalesEntries.Select(saleEntry => _mapper.Map<SaleProduct>(saleEntry)).ToList();
        var discount = GetDiscount(saleProducts);
        var sale = new Sale
        {
            SaleProducts = saleProducts,
            UserId = request.UserId,
            SaleDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            Status = SaleStatus.Created,
            Price = saleProducts.Sum(saleProduct => saleProduct.Price * saleProduct.Quantity),
            DiscountPercentage = discount
        };

        return sale;
    }

    private int GetDiscount(List<SaleProduct> saleProducts)
    {
        if (saleProducts.Where(a => a.Quantity >= 10).Any())
            return 20;
        
        if (saleProducts.Where(a => a.Quantity > 4).Any())
            return 10;
        
        return 0;
    }
}