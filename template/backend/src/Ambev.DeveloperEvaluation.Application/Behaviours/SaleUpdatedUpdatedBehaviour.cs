using Ambev.DeveloperEvaluation.Application.Behaviours.BehaviourInterfaces;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Behaviours;

public class SaleUpdatedUpdatedBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ISaleUpdatedBehaviour
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();
        
        // send notification to a queue
        Console.WriteLine($"Sale {request} updated");
        
        return response;
    }
}