using DataLayer.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataLayer.EF
{
    public class EfTransactionManager : ITransactionManager
    {
        private readonly DbContext _dbContext;
        private IDbContextTransaction transaction1;

        public EfTransactionManager(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            transaction1 = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
            transaction1.Commit();
        }

        public void Rollback()
        {           
            transaction1.Rollback();
        }
    }
}
