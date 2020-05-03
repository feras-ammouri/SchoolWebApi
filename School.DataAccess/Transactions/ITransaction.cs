using System;
using System.Collections.Generic;
using System.Text;

namespace School.DataAccess.Transactions
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
