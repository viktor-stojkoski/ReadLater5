namespace Shared.Mediator
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IReadLaterPublisher
    {
        /// <summary>
        /// Executes a command.
        /// </summary>
        Task<TResult> ExecuteAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);

        /// <summary>
        /// Executes a query.
        /// </summary>
        Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
    }
}
