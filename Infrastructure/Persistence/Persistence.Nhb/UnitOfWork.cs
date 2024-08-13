// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using Microsoft.Extensions.Logging;
using NHibernate;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;
        private ISession? _session;
        private ITransaction? _transaction;

        public UnitOfWork(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        internal ISession Session
        {
            get
            {
                if (_session == null)
                    throw new InvalidOperationException("You are not in a unit of work.");
                return _session;
            }
        }

        public void Begin()
        {
            Task.Run(async () => await DisposeTransaction());
            _session = _unitOfWorkFactory.CreateSession();
            _session.FlushMode = FlushMode.Commit;
            _transaction = _session.BeginTransaction();
        }
        public async Task BeginAsync()
        {
            await DisposeTransaction();
            _session = _unitOfWorkFactory.CreateSession();
            _session.FlushMode = FlushMode.Commit;
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                throw;
            }
            finally
            {
                Task.Run(async () => await DisposeTransaction());
            }
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                try
                {
                    await _transaction.CommitAsync();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    await DisposeTransaction();
                }
            }
        }

        public void Rollback()
        {
            Task.Run(async () => await DisposeTransaction());
        }

        public Task RollbackAsync()
            => DisposeTransaction();

        private async Task DisposeTransaction()
        {
            if (_session != null)
            {
                try
                {
                    if (_transaction != null)
                    {
                        try
                        {
                            if (_transaction.IsActive)
                            {
                                await _transaction.RollbackAsync();
                            }
                            _transaction.Dispose();
                            _transaction = null!;
                        }
                        catch (Exception ex)
                        {
                            throw new HibernateException("Unable to rollback transaction for orphaned session", ex);
                        }
                    }
                    _session.Close();
                    _session.Dispose();
                    _session = null!;
                }
                catch (Exception ex)
                {
                    throw new HibernateException("Unable to close orphaned session", ex);
                }
            }
        }

        public void Dispose()
        {
            Task.Run(async () => await DisposeTransaction());
        }
    }
}
