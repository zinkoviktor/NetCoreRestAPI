using DataLayer.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataLayer.EF
{
    public class EfTransactionManager : ITransactionManager
    {
        private readonly DbContext _dbContext;
        private IDbContextTransaction transaction;

        public EfTransactionManager(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            transaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
            transaction.Commit();
        }

        public void Rollback()
        {           
            transaction.Rollback();
        }
    }
}
