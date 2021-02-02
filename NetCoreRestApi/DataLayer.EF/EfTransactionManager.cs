using DataLayer.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataLayer.EF
{
    public class EfTransactionManager : ITransactionManager
    {
        private readonly DbContext _dbContext;
        private IDbContextTransaction _transactionManager = null;

        public EfTransactionManager(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            if(_transactionManager == null)
            {
                _transactionManager = _dbContext.Database.BeginTransaction();
            }            
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
            _transactionManager.Commit();
        }

        public void Dispose()
        {
            _transactionManager.Dispose();
        }

        public void Rollback()
        {           
            _transactionManager.Rollback();
        }
    }
}
