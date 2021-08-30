namespace Shared.Mediator
{
    using MediatR;

    /// <summary>
    /// Marker interface to represent query.
    /// </summary>
    public interface IQuery<out TResult> : IRequest<TResult> { }
}
