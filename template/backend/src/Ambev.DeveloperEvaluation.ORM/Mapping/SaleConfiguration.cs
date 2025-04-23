using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(50);
        
        builder.Ignore(x => x.Total);
        builder.Ignore(x => x.DiscountApplied);
    }
}