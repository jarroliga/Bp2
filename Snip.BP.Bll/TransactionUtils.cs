using System;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snip.BP.Bll
{
    public class TransactionUtils
    {
        public static TransactionScope CreateTransactionScope()
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;
            transactionOptions.Timeout = TimeSpan.MaxValue;
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }

    }
}
