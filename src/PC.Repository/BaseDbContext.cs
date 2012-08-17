using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PebbleCode.Framework.IoC;

namespace PebbleCode.Repository
{
    public abstract class BaseDbContext
    {
        public RepositoryTransaction BeginTransaction()
        {
            return Kernel.Get<TransactionProvider>().BeginTransaction();
        }
    }

}
