using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;

    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product?> GetByProductIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.Where(product => product.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        var updateProduct = await _context.Products.Where(prd => prd.Id == product.Id)
            .FirstOrDefaultAsync(cancellationToken);
        if (updateProduct == null) 
            throw new NullReferenceException($"Product with id {product.Id} was not found");

        updateProduct.Name = product.Name;
        updateProduct.Description = product.Description;
        updateProduct.Price = product.Price;
        updateProduct.Stock = product.Stock;

        _context.Products.Update(updateProduct);
        await _context.SaveChangesAsync(cancellationToken);
        return updateProduct;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products.Where(prd => prd.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
        if (product == null) throw new NullReferenceException($"Product with id {id} was not found");
        
        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
    }
}