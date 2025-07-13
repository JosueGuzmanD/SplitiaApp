namespace Splitia.Application.Abstraction.Messaging.Commands;

public interface ICommandHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    Task<TResponse> Handle(TCommand command);
}

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task Handle(TCommand command);
}