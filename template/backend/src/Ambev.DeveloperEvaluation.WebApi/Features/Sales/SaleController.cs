using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Sales.NewSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSaleStats;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.NewSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSaleStatus;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

[ApiController]
[Route("api/[controller]")]
public class SaleController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SaleController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<NewSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> NewSale(NewSaleRequest request,
        CancellationToken cancellationToken)
    {
        var validator = new NewSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<NewSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<NewSaleResponse>
        {
            Success = true,
            Message = "New sale created successfully",
            Data = _mapper.Map<NewSaleResponse>(response)
        });
    }
    
    [HttpPost("{id:guid}/status")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleStatusResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateStatus(Guid id, UpdateSaleStatusRequest request,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateSaleStatusCommand>(request);
        command.Id = id;
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<UpdateSaleStatusResponse>
        {
            Success = true,
            Message = "Sale updated.",
            Data = _mapper.Map<UpdateSaleStatusResponse>(response)
        });
    }
}