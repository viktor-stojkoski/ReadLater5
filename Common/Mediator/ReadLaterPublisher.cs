namespace Shared.Mediator
{
    using System.Threading;
    using System.Threading.Tasks;

    public class ReadLaterPublisher : IReadLaterPublisher
    {
        private readonly ReadLaterMediator _readLaterMediator;

        public ReadLaterPublisher(ReadLaterMediator readLaterMediator)
        {
            _readLaterMediator = readLaterMediator;
        }

        public async Task<TResult> ExecuteAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken)
        {
            return await _readLaterMediator.Send(command, cancellationToken);
        }

        public async Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
        {
            return await _readLaterMediator.Send(query, cancellationToken);
        }
    }
}
