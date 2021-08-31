namespace Shared.Mediator
{
    using MediatR;

    /// <summary>
    /// Marker interface to represent command.
    /// </summary>
    public interface ICommand<out TResult> : IRequest<TResult> { }
}
