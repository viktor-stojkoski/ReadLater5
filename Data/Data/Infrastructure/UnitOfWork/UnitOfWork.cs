namespace Storage.Infrastructure.UnitOfWork
{
    using System;
    using System.Threading.Tasks;

    using Contracts.Infrastructure;

    using Storage.Infrastructure.Context;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IReadLaterDbContext _readLaterDbContext;
        private bool _isDisposed;

        public UnitOfWork(IReadLaterDbContext readLaterDbContext)
        {
            _readLaterDbContext = readLaterDbContext;
        }

        public async Task SaveAsync()
        {
            await _readLaterDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _readLaterDbContext.Dispose();
                }

                _isDisposed = true;
            }
        }
    }
}
