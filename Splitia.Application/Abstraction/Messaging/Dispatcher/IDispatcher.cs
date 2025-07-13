using Splitia.Application.Abstraction.Messaging.Commands;
using Splitia.Application.Abstraction.Messaging.Queries;

namespace Splitia.Application.Abstraction.Messaging.Dispatcher;

public interface IDispatcher
{
    Task Send(ICommand command);
    Task<TResponse> Send<TResponse>(ICommand<TResponse> command);
    Task<TResponse> Send<TResponse>(IQuery<TResponse> query);
}