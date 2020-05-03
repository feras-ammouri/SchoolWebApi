using Microsoft.EntityFrameworkCore.Storage;

namespace School.DataAccess.Transactions
{
    public class DbTransaction : ITransaction
    {
        private readonly IDbContextTransaction _dbContextTransaction;

        public DbTransaction(IDbContextTransaction dbContextTransaction)
        {
            this._dbContextTransaction = dbContextTransaction;
        }

        public void Commit()
        {
            this._dbContextTransaction.Commit();
        }

        public void Rollback()
        {
            this._dbContextTransaction.Rollback();
        }

        public void Dispose()
        {
            this._dbContextTransaction.Dispose();
        }
    }
}
