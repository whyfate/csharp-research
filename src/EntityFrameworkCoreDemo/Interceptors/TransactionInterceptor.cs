using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Interceptors
{
    /// <summary>
    /// 事务拦截器.
    /// </summary>
    public class TransactionInterceptor: DbTransactionInterceptor
    {
        public override Task CreatedSavepointAsync(DbTransaction transaction, TransactionEventData eventData, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(CreatedSavepointAsync)}---invoke---");

            return base.CreatedSavepointAsync(transaction, eventData, cancellationToken);
        }

        public override Task ReleasedSavepointAsync(DbTransaction transaction, TransactionEventData eventData, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(ReleasedSavepointAsync)}---invoke---");

            return base.ReleasedSavepointAsync(transaction, eventData, cancellationToken);
        }

        public override Task RolledBackToSavepointAsync(DbTransaction transaction, TransactionEventData eventData, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(RolledBackToSavepointAsync)}---invoke---");

            return base.RolledBackToSavepointAsync(transaction, eventData, cancellationToken);
        }

        public override ValueTask<InterceptionResult> TransactionCommittingAsync(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(TransactionCommittingAsync)}---invoke---");

            return base.TransactionCommittingAsync(transaction, eventData, result, cancellationToken);
        }

        public override Task TransactionCommittedAsync(DbTransaction transaction, TransactionEndEventData eventData, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(TransactionCommittedAsync)}---invoke---");

            return base.TransactionCommittedAsync(transaction, eventData, cancellationToken);
        }

        public override Task TransactionFailedAsync(DbTransaction transaction, TransactionErrorEventData eventData, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(TransactionFailedAsync)}---invoke---");

            return base.TransactionFailedAsync(transaction, eventData, cancellationToken);
        }

        public override Task TransactionRolledBackAsync(DbTransaction transaction, TransactionEndEventData eventData, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(TransactionRolledBackAsync)}---invoke---");

            return base.TransactionRolledBackAsync(transaction, eventData, cancellationToken);
        }

        public override ValueTask<DbTransaction> TransactionStartedAsync(DbConnection connection, TransactionEndEventData eventData, DbTransaction result, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(TransactionStartedAsync)}---invoke---");

            return base.TransactionStartedAsync(connection, eventData, result, cancellationToken);
        }

        public override ValueTask<InterceptionResult<DbTransaction>> TransactionStartingAsync(DbConnection connection, TransactionStartingEventData eventData, InterceptionResult<DbTransaction> result, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(TransactionStartingAsync)}---invoke---TransactionId:{eventData.TransactionId}");

            return base.TransactionStartingAsync(connection, eventData, result, cancellationToken);
        }

        public override ValueTask<DbTransaction> TransactionUsedAsync(DbConnection connection, TransactionEventData eventData, DbTransaction result, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(TransactionUsedAsync)}---invoke---");

            return base.TransactionUsedAsync(connection, eventData, result, cancellationToken);
        }
    }
}
