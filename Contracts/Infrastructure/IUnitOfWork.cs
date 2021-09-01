﻿namespace Shared.Infrastructure
{
    using System;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Persists changes to storage.
        /// </summary>
        Task SaveAsync();
    }
}
