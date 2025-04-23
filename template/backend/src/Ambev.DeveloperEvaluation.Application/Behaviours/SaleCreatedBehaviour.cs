using System.Text.Json.Serialization;
using Ambev.DeveloperEvaluation.Application.Behaviours.BehaviourInterfaces;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Behaviours;

public class SaleCreatedBehaviour <TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ISaleCreatedBehaviour
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();
        
        // send notification to a queue
        Console.WriteLine($"Sale {request} created");
        
        return response;
    }
}
