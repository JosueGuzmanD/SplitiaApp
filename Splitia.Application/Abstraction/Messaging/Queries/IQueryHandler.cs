namespace Splitia.Application.Abstraction.Messaging.Queries;

public interface IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    Task<TResponse> Handle(TQuery query);
}