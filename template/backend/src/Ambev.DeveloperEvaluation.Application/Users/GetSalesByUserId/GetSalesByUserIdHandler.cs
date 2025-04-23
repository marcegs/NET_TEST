using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.GetSalesByUserId;

public class GetSalesByUserIdHandler : IRequestHandler<GetSalesByUserIdCommand, GetSalesByUserIdResult>
{
    public Task<GetSalesByUserIdResult> Handle(GetSalesByUserIdCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}