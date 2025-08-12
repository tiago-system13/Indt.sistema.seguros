using MediatR;

namespace Indt.Sistema.Seguros.App.API.Shared
{
    public interface IHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }
}
