﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Platform.Infrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        Task BeginTransactionAsync();

        void SaveChanges();

        Task SaveChangesAsync();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
