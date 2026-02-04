using MediatR;

namespace Clean.Architecture.Application.Abstractions.Messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
