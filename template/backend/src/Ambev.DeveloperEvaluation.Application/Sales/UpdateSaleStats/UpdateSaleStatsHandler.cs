using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSaleStats;

public class UpdateSaleStatsHandler : IRequestHandler<UpdateSaleStatusCommand, UpdateSaleStatsResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public UpdateSaleStatsHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSaleStatsResult> Handle(UpdateSaleStatusCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.UpdateStatusAsync(request.Id, request.Status, cancellationToken);
        return _mapper.Map<UpdateSaleStatsResult>(sale);
    }
}