using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.NewSale;

public class NewSaleValidator : AbstractValidator<NewSaleCommand>
{
    public NewSaleValidator()
    {
        RuleFor(x => x.SalesEntries).NotNull();
        RuleFor(x => x.SalesEntries).NotEmpty();

        RuleForEach(a => a.SalesEntries)
            .ChildRules(entry =>
            {
                entry.RuleFor(saleEntry => saleEntry.Quantity).GreaterThan(0);
                entry.RuleFor(saleEntry => saleEntry.Quantity).LessThan(20);
                entry.RuleFor(saleEntry => saleEntry.Price).GreaterThan(0);
            });
    }
}