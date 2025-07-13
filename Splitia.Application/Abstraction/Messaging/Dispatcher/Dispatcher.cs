using Splitia.Application.Abstraction.Messaging.Commands;
using Splitia.Application.Abstraction.Messaging.Queries;

namespace Splitia.Application.Abstraction.Messaging.Dispatcher;

public class Dispatcher(IServiceProvider serviceProvider) : IDispatcher
{
    public Task Send(ICommand command)
    {
        var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
        var handler = serviceProvider.GetService(handlerType);

        if (handler == null)
        {
            throw new Exception($"Handler not found for type {command.GetType()}");
        }

        var method = handlerType.GetMethod("Handle");

        return (Task)method.Invoke(handler, new object[] { command });
    }

    public Task<TResponse> Send<TResponse>(ICommand<TResponse> command)
    {
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResponse));
        var handler = serviceProvider.GetService(handlerType);

        if (handler == null)
        {
            throw new Exception($"Handler not found for type {command.GetType()}");
        }

        var method = handlerType.GetMethod("Handle");

        return (Task<TResponse>)method.Invoke(handler, new object[] { command });
    }

    public Task<TResponse> Send<TResponse>(IQuery<TResponse> query)
    {
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResponse));
        var handler = serviceProvider.GetService(handlerType);
        if (handler == null)
        {
            throw new Exception($"Handler not found for type {query.GetType()}");
        }

        var method = handlerType.GetMethod("Handle");
        return (Task<TResponse>)method.Invoke(handler, new object[] { query });
    }
}