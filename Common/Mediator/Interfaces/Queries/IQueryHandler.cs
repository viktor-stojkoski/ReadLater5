namespace Shared.Mediator
{
    using MediatR;

    /// <summary>
    /// Defines a handler for queries.
    /// </summary>
    /// <typeparam name="TQuery">Type of the query to be executed.</typeparam>
    /// <typeparam name="TResult">Query return type.</typeparam>
    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    { }
}
