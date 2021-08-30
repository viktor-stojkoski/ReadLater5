namespace Shared.Mediator
{
    using MediatR;

    /// <summary>
    /// Defines a handler for commands.
    /// </summary>
    /// <typeparam name="TCommand">Type of the command to be executed.</typeparam>
    /// <typeparam name="TResult">Command return type.</typeparam>
    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    { }
}
